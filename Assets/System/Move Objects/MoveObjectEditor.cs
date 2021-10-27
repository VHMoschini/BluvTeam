using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR

[CustomEditor(typeof(MoveObject))]
public class MoveObjectEditor : Editor
{

    MoveObject baseScript;

    //bool foldout;

    void Awake()
    {
        baseScript = (MoveObject)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical();
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Reset Posição"))
            {
                baseScript.gameObject.transform.localPosition = baseScript.p_Inicial;
                baseScript.gameObject.transform.localEulerAngles = baseScript.r_Inicial;
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(5);
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Transform Inicial"))
            {
                baseScript.p_Inicial = baseScript.gameObject.transform.localPosition;
                baseScript.r_Inicial = baseScript.gameObject.transform.localEulerAngles;
            }
            if (GUILayout.Button("Transform Final"))
            {
                baseScript.p_final = baseScript.gameObject.transform.localPosition;
                baseScript.r_final = baseScript.gameObject.transform.localEulerAngles;
            }

            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();

        if (GUI.changed)
            EditorUtility.SetDirty(target);

        GUILayout.Space(10);

        //EditorGUILayout.SelectableLabel("Teste");
        //EditorGUILayout.HelpBox("teste", MessageType.Warning);


        //GUIContent content = new GUIContent();
        //content.text = "Ola o texto do foldOut";
        //EditorGUILayout.Foldout(true, content, true);

        //EditorGUILayout.Vector3Field("Position", Vector3.zero);

        base.OnInspectorGUI();
        //GUIStyle style = new GUIStyle();
        //style.fontSize = 54;

        //foldout = EditorGUILayout.Foldout(foldout, "Transform Inicial",style);

        //if (foldout)
        //{
        //    base.OnInspectorGUI();
        //}

    }
}
#endif
