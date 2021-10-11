using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private GameObject entrada;
    private GameObject saida;

    private Player player;

    public bool isLimited = false;
    public int loopLife = 0;

    void Awake()
    {
        entrada = transform.GetChild(1).gameObject;
        saida = transform.GetChild(0).gameObject;

        player = (Player)FindObjectOfType(typeof(Player));
    }

    private void Update()
    {
        Debug.Log(loopLife);
    }

    public void Entrada()
    {
        player.TeleportTo(entrada);

        UseLoopLife();
    }

    public void Saida()
    {

    }

    private void UseLoopLife()
    {
        if (!isLimited) return;

        loopLife--;

        if (loopLife <= 0)
        {
            entrada.SetActive(false);
            saida.SetActive(false);
        }
    }
}

[CustomEditor(typeof(Loop)), CanEditMultipleObjects,]
public class LoopEditor : Editor
{
    bool checkbox;

    private Loop baseScript;
    int life = 10;

    void Awake()
    {
        baseScript = (Loop)target;
    }
    public override void OnInspectorGUI()
    {
        //base.DrawDefaultInspector();

        baseScript.isLimited = EditorGUILayout.BeginToggleGroup("isLimited", baseScript.isLimited);
        if (baseScript.isLimited)
        {
            baseScript.loopLife = EditorGUILayout.IntField("Loop life", baseScript.loopLife);
            //baseScript.loopLife = life;
        }
        EditorGUILayout.EndToggleGroup();
    }
}



