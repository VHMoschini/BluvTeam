using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constantes
{
    // PLAYER PREF SCHEME

    // CONFIGURA��ES
    // Vision.cs - Sensibilidade do mouse
    public static string SENSIBILITY_SAVE = "SENSIBILITY_SAVE";


    // GAMEPLAY
    //SystemManager.cs - Estado Atual do HUB
    public static string HUB_STATE = "HUB_STATE";

    // SOUND
    // Volume Master

    // Voume Musica
    // Volume SFX
    // Volume Voz

    // Variavel de Layer da musica
    // Variavel de transi��o

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