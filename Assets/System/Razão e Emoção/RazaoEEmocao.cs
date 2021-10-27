using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// Interface externa da classe
//      => Bloquear a mudança para o jogador 
//      => Desbloquear a mudança para o jogador 
//      => Fazer a mudança de realidade

public class RazaoEEmocao : MonoBehaviour
{
    //public  List<GameObject> Razao;      // Objetos da razão
    //public  List<GameObject> Emocao;     // Objestos da emoção

    public static List<RazaoEEmocao> objs = new List<RazaoEEmocao>();

    public bool manager;

    //public bool lockState = true;       // Variavel de controle do jogador

    private void Awake()
    {
        if (!manager) return;

        //objs.Add(gameObject);
        objs = GetAllObjectsOnlyInScene();
    }

    List<RazaoEEmocao> GetAllObjectsOnlyInScene()
    {
        List<RazaoEEmocao> objectsInScene = new List<RazaoEEmocao>();

        foreach (RazaoEEmocao go in Resources.FindObjectsOfTypeAll(typeof(RazaoEEmocao)) as RazaoEEmocao[])
        {
            //if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                if ( !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                    objectsInScene.Add(go);
        }

        return objectsInScene;
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(1) && lockState)    // Quando o Player Clicar com o botão direito do mouse e a mudança está desbloqueada
        //{
        //    razaoEEmocao();
        //}
    }

    public void razaoEEmocao()
    {
        foreach (RazaoEEmocao obj in objs)
        {
            if (obj.manager) return;
            switchState(obj.gameObject);
        }


        //foreach (GameObject obj in Razao)
        //    switchState(obj);

        //foreach (GameObject obj in Emocao)
        //    switchState(obj);
    }

    public void switchState(GameObject obj) => obj.SetActive(!obj.activeSelf);     // Inverte o estado do objeto em questão
                                                                                   //public void LockChange() => lockState = false;      // Bloqueia a mudança da Razão e Emoção para o jogador
                                                                                   //public void UnlockChange() => lockState = true;     // Desbloqueia a mudança da Razão e Emoção para o jogador

    //public void OnDrawGizmos()
    //{
    //    if (manager || objs.Contains(gameObject)) return;

    //    objs.Add(gameObject);
    //}
}

#if UNITY_EDITOR


[CustomEditor(typeof(RazaoEEmocao))]
public class REEditor : Editor
{
    private RazaoEEmocao baseScript;

    private List<RazaoEEmocao> objs;

    void Awake()
    {
        baseScript = (RazaoEEmocao)target;
    }
    public override void OnInspectorGUI()
    {
        baseScript.manager = EditorGUILayout.BeginToggleGroup("Manager", baseScript.manager);
        if (baseScript.manager)
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Mudar Realidade"))
            {
                objs = GetAllObjectsOnlyInScene();

                foreach (RazaoEEmocao obj in objs)
                {
                    if (obj.manager) return;
                    obj.gameObject.SetActive(!obj.gameObject.activeSelf);
                }

            }

            GUILayout.EndHorizontal();

        }
        EditorGUILayout.EndToggleGroup();
    }

    List<RazaoEEmocao> GetAllObjectsOnlyInScene()
    {
        List<RazaoEEmocao> objectsInScene = new List<RazaoEEmocao>();

        foreach (RazaoEEmocao go in Resources.FindObjectsOfTypeAll(typeof(RazaoEEmocao)) as RazaoEEmocao[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }
}

#endif