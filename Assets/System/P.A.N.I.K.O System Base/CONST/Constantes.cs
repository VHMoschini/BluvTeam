using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Constantes
{
    // PLAYER PREF SCHEME

    // CONFIGURA��ES
    // Vision.cs - Sensibilidade do mouse
    public static string SENSIBILITY_SAVE = "SENSIBILITY_SAVE";

    // SOUND
    // Volume Master
    public static string MASTER_SAVE = "COLECTABLE_LIST";

    // Variavel de Layer da musica
    public static string MUSIC_LAYER_SAVE = "COLECTABLE_LIST";

    // Variavel de transi��o
    public static string MUSIC_TRANSITION_SAVE = "COLECTABLE_LIST";


    // GAMEPLAY
    //SystemManager.cs - Estado Atual do HUB
    public static string HUB_STATE = "HUB_STATE";

    // COLECIONAVEIS
    public static string COLECTABLE_LIST = "COLECTABLE_LIST";

    // DELETE_LIST
    // Lista de chaves que ser�o reiniciadas quando iniciar o jogo.
    public static string[] DELETE_LIST = { HUB_STATE, COLECTABLE_LIST };
}

[Serializable]
public enum Colectable
{
    Item_Fase_1,
    Item_Fase_2,
    Item_Fase_3,
    Item_Fase_4,
    Item_Fase_5
}


public enum HUBStatus
{
    anim_01, // Ao iniciar o jogo a primeira anima��o de introdu��o
    anim_02, // Ao sair do hospital  
    anim_03, // Ao sair da casa, na segunda fase
    anim_04, // Ao sair do metro, terceira fase
    anim_05, // Ao sair da casa, quarta fase

    anim_06 // Anima��o final do jogo, quando sai da quinta fase
}