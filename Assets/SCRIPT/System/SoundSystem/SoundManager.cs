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

    [SerializeField]
    private FMODUnity.StudioEventEmitter emitter;

    void Start()
    {
    }

    private void Update()
    {
        emitter.EventInstance.setParameterByName(soundParameters.LayerController.ToString(), floatingNumber);
        emitter.EventInstance.setParameterByName(soundParameters.Transitions.ToString(), integerNumber);
    }

    public void IncrementLayer() => StartCoroutine(fadeNumber());
    public void DecrementLayer() => StartCoroutine(fadeNumber(false));

    public void ChangeTransition(int transitionNumber) => integerNumber = transitionNumber;

    IEnumerator fadeNumber(bool toUp = true)
    {
        float targetNumber;

        if (toUp) targetNumber = floatingNumber + 1;
        else targetNumber = floatingNumber - 1;

        while (floatingNumber != targetNumber)
        {
            if (toUp)
            {
                floatingNumber += 0.05f;
                if (floatingNumber > targetNumber) floatingNumber = targetNumber;
            }
            else
            {
                floatingNumber -= 0.05f;
                if (floatingNumber < targetNumber) floatingNumber = targetNumber;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}

#if UNITY_EDITOR

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

#endif
