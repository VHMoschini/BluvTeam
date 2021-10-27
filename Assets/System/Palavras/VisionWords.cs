using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class VisionWords : MonoBehaviour
{
    [SerializeField] private float range = 3;
    public float rightAngle;
    public float holdTime = 10;

    [Space(10)]

    public GameObject words;

    [Space(10)]


    public UnityEvent FindWord;


    private IEnumerator coroutine;
    private bool execution;

    private void Start()
    {
        coroutine = HoldCooldown(holdTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            var actualRotation = other.transform.eulerAngles.y;

            if (actualRotation > rightAngle - range && actualRotation < rightAngle + range && !execution)
            {
                StartCoroutine(coroutine);
            }
        }
    }

    IEnumerator HoldCooldown(float _holdTime)
    {
        execution = true;

        yield return new WaitForSeconds(_holdTime);

        gameObject.SetActive(false);
        words.SetActive(false);
        FindWord.Invoke();
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(VisionWords))]
public class WordsEditor : Editor
{
    VisionWords baseScript;

    public void Awake()
    {
        baseScript = (VisionWords)target;
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Position"))
        {
            baseScript.gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;

        }
        if (GUILayout.Button("Rotation"))
        {
            baseScript.rightAngle = GameObject.FindGameObjectWithTag("Player").gameObject.transform.eulerAngles.y;
        }

        EditorGUILayout.Space(5);

        base.OnInspectorGUI();

        if (GUI.changed)
            EditorUtility.SetDirty(target);

        EditorUtility.CopySerialized(baseScript.gameObject, baseScript.gameObject);

    }
}

#endif


/*
 * TODO
 Comparar a distancia do jogador com esse objeto, e pegar a diferen�a e criar um glow que aumenta quanto mais perto
o jogador estiver
 */

/*
Static property array of game object de emo��o e um outro de raz�o

Uma boolean que diz se o objeto � o admin do raz�o e emo��o ou n�o
Case seja muda o editor com as propriedades adequadas, se n�o usa as propriedades de objetos a serem ligado e desligados.
 
 */
