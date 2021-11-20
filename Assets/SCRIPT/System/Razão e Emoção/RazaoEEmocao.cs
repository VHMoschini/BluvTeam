using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

// Interface externa da classe
//      => Bloquear a mudança para o jogador 
//      => Desbloquear a mudança para o jogador 
//      => Fazer a mudança de realidade

public class RazaoEEmocao : MonoBehaviour
{
    public List<GameObject> Razao;      // Objetos da razão
    public List<GameObject> Emocao;     // Objestos da emoção

    public PlayableDirector PD;

    [Space(10)]

    public PlayableAsset TransitionWithArms;
    public PlayableAsset TransitionWithoutArms;


    //public static List<RazaoEEmocao> objs = new List<RazaoEEmocao>();

    //public bool manager;

    //public bool lockState = true;       // Variavel de controle do jogador

    private void Awake()
    {
        //if (!manager) return;

        //objs.Add(gameObject);
        //objs = GetAllObjectsOnlyInScene();
    }

    //List<RazaoEEmocao> GetAllObjectsOnlyInScene()
    //{
    //    List<RazaoEEmocao> objectsInScene = new List<RazaoEEmocao>();

    //    foreach (RazaoEEmocao go in Resources.FindObjectsOfTypeAll(typeof(RazaoEEmocao)) as RazaoEEmocao[])
    //    {
    //        if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
    //            //if ( !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
    //            objectsInScene.Add(go);
    //    }

    //    return objectsInScene;
    //}

    private void Update()
    {
        //if (Input.GetMouseButtonDown(1) && lockState)    // Quando o Player Clicar com o botão direito do mouse e a mudança está desbloqueada
        //{
        //    razaoEEmocao();
        //}

    }

    public void razaoEEmocao()
    {
        /*
         Trocar o clip e dar play na timeline
         */


        //PD.playableAsset

        if (Razao[0].activeSelf == false)
        {
            PD.playableAsset = TransitionWithoutArms;
            PD.Play();
        }
        else
        {
            PD.playableAsset = TransitionWithArms;
            PD.Play();
        }
    }

    public void animationReality()
    {
        //foreach (RazaoEEmocao obj in objs)
        //{
        //    switchState(obj.gameObject);
        //}

        //if (obj.manager) return;

        foreach (GameObject obj in Razao)
            switchState(obj);

        foreach (GameObject obj in Emocao)
            switchState(obj);
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


[CustomEditor(typeof(RazaoEEmocao)), CanEditMultipleObjects]
public class REEditor : Editor
{
    private RazaoEEmocao baseScript;

    void Awake()
    {
        baseScript = (RazaoEEmocao)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Mudar Realidade"))
        {
            baseScript.razaoEEmocao();
        }

        GUILayout.EndHorizontal();
    }
}

#endif