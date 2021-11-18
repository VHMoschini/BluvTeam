using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakAndSubtittleController : MonoBehaviour
{
    public GameObject Subtittle;     //Objeto do canvas com a legenda da fala atual. Se for possível fazer uma parte do script pra dar um fade in e fade out é um polimento legal de ter

    [SerializeField]
    private FMODUnity.StudioEventEmitter VoiceLine;  //Studio Event Emmiter que contém a fala

    public GameObject NextLine;  // Próximo gameobject que contém fala

    /*
    public GameObject ObjectToActivate; 

     Isso tava aqui pra ativar/desativar algum game object vinculado, se o Vitão ou alguém conseguir fazer a boa de colocar o mesmo esquema dos triggers
    pra fazer esse script puxar outras interações eu pago 01 pacotinho de bala de menta Garoto :D
    */

    public bool startAway = false;   //Faz a fala ativar no start do objeto
    public bool isEnding = false;    //Marca a fala atual como a última fila/sequência, mesmo se tiverem outras vinculadas elas não irão tocar quando a atual terminar

    //public bool enableSomething = false;
    //public bool disableSomething = false;

    private bool isActive = false;
    private bool ended = false;

    void Start()
    {
        if (startAway == true) StartPlay();

       /* if(enableSomething == true || disableSomething == true)
        {
            if(ObjectToActivate == null)
            {
                Debug.Log("This script will try to enable or disable an object but no reference was found");
            }
        } */
    }

    void Update()
    {
        if(isActive == true && ended == false) //Verifica se o evento foi ativado e se não foi tocado ainda
        {
            if(VoiceLine.IsPlaying() == false)
            {
                if (isEnding == true) //Verifica se o evento é o último da fila e finaliza a execução
                {
                    Debug.Log("Queue ended, last event played was " + VoiceLine.gameObject.name);
                    ended = true;

                    DisableSelf();
                }
                else if (NextLine == null) //Verifica se nenhum objeto foi vinculado como próximo da fila e finaliza a execução
                {
                    Debug.Log("Queue stopped, no next line was found");
                    ended = true;

                    DisableSelf();
                }
                else StartNext(); //Inicia o próximo evento da fila

            }
        }
    }

    public void StartPlay() //Comanda a ativação do audio e da legenda
    {
        if(ended == false)
        {
            if (VoiceLine.IsPlaying() != true && isActive == false) //Verifica se o evento já está tocando antes de iniciar
            {
                VoiceLine.Play();
                isActive = true;
                Subtittle.SetActive(true);

                Debug.Log("Playing " + VoiceLine.gameObject.name);
            }

            /* if (enableSomething == true)
            {
                ObjectToActivate.SetActive(true);
            } */
        } else Debug.Log("The line " + VoiceLine.gameObject.name + " is playing or was already played once, check objects references");

    }

    void StartNext() //Toca o próximo evento da fila
    {
        Debug.Log("Started next line " + NextLine.name);
        NextLine.GetComponent<SpeakAndSubtittleController>().StartPlay();

        ended = true;
        DisableSelf();
    }

    void DisableSelf() //Desabilita a legenda atual, acho legal colocar um timer de 1 ou 2 segundos para desabilitar mas não tive tempo de fazer
    {
        /* if(disableSomething == true)
        {
            ObjectToActivate.SetActive(false);
        }
        */

        Subtittle.SetActive(false);
        
    }
}
