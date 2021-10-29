using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FadeBlur : MonoBehaviour
{
    public Material blurMaterial;

    public float opacity = 2;
    public float amount = 0.1f;

    private void Start()
    {
        blurMaterial.SetFloat("_Size", 0);
    }

    private void Update()
    {
    }

    public void IncrementLayer() => StartCoroutine(fadeNumber(amount));
    public void DecrementLayer() => StartCoroutine(fadeNumber(amount, false));

    IEnumerator fadeNumber(float _amount, bool toUp = true)
    {
        if (toUp)
        {
            while (blurMaterial.GetFloat("_Size") != opacity)
            {
                blurMaterial.SetFloat("_Size", blurMaterial.GetFloat("_Size") + _amount);

                if (blurMaterial.GetFloat("_Size") > opacity)
                {
                    blurMaterial.SetFloat("_Size", opacity);
                }
                yield return new WaitForSeconds(0.1f);

            }
        }
        else
        {
            while (blurMaterial.GetFloat("_Size") != 0)
            {
                blurMaterial.SetFloat("_Size", blurMaterial.GetFloat("_Size") - _amount);

                if (blurMaterial.GetFloat("_Size") < 0)
                {
                    blurMaterial.SetFloat("_Size", 0);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(FadeBlur))]
public class FadeBlurEditor : Editor
{
    FadeBlur baseScript;

    public void Awake()
    {
        baseScript = (FadeBlur)target;
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Increment"))
        {
            baseScript.IncrementLayer();
        }
        EditorGUILayout.Space(5);
        if (GUILayout.Button("Decrement"))
        {
            baseScript.DecrementLayer();
        }
        EditorGUILayout.Space(5);

        base.OnInspectorGUI();
    }
}

#endif
