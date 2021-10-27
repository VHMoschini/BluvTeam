using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum soundParameters
{
    Transitions,
    LayerController
}

public class SoundManager : MonoBehaviour
{
    private int integerNumber;
    private float floatingNumber;

    public soundParameters ParameterName;

    [SerializeField]
    private FMODUnity.StudioEventEmitter emitter;

    void Start()
    {
        Debug.Log(ParameterName.ToString());

        emitter = GetComponent<StudioEventEmitter>();
    }

    private void Update()
    {
        Debug.Log(floatingNumber);


        emitter.EventInstance.setParameterByName(ParameterName.ToString(), floatingNumber);
    }

    public void IncrementLayer() => StartCoroutine(fadeNumber());
    public void DecrementLayer() => StartCoroutine(fadeNumber(false));

    IEnumerator fadeNumber(bool toUp = true)
    {
        float targetNumber;

        if (toUp) targetNumber = floatingNumber + 1;
        else targetNumber = floatingNumber - 1;

        while (floatingNumber != targetNumber)
        {
            if (toUp)
            {
                floatingNumber += 0.01f;
                if (floatingNumber > targetNumber) floatingNumber = targetNumber;
            }
            else
            {
                floatingNumber -= 0.01f;
                if (floatingNumber < targetNumber) floatingNumber = targetNumber;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}

[CustomEditor(typeof(SoundManager))]
public class SoundManagerEditor : Editor
{
    SoundManager baseScript;

    public void Awake()
    {
        baseScript = (SoundManager)target;
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Increment"))
        {
            baseScript.IncrementLayer();
        }
        if (GUILayout.Button("Decrement"))
        {
            baseScript.DecrementLayer();
        }

        EditorGUILayout.Space(5);

        base.OnInspectorGUI();

        if (GUI.changed)
            EditorUtility.SetDirty(target);

        EditorUtility.CopySerialized(baseScript.gameObject, baseScript.gameObject);

    }
}
