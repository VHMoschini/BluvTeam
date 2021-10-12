using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VisionWords))]
public class WordsEditor : Editor
{
    VisionWords baseScript;

    public void Awake(){
        baseScript = (VisionWords)target;
    }
     public override void OnInspectorGUI()
     {
         base.OnInspectorGUI();
        if(GUILayout.Button("Position")){
            baseScript.gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position; 

        }
        if(GUILayout.Button("Rotation")){
            baseScript.rightAngle = GameObject.FindGameObjectWithTag("Player").gameObject.transform.eulerAngles.y; 
        }

         if (GUI.changed)
            EditorUtility.SetDirty(target);
            EditorUtility.CopySerialized(baseScript.gameObject, baseScript.gameObject);
     }
}
