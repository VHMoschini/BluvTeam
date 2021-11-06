using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;


public class MoveObject : MonoBehaviour, IInteragivel
{
    // [ Pra implementar a interface deve ser feito essa implementação ]
    [Space(10)]
    public bool Interagivel = true;
    bool IInteragivel.interagivel { get => Interagivel; }

    [Header("Transform Inicial")]
    [SerializeField] public Vector3 p_Inicial = Vector3.zero;
    [SerializeField] public Vector3 r_Inicial = Vector3.zero;

    [Header("Transform Final")]
    [SerializeField] public Vector3 p_final = Vector3.zero;
    [SerializeField] public Vector3 r_final = Vector3.zero;

    [Space(10)]

    [SerializeField] float speed = 200;

    private Vector3 targetPosition;
    private Vector3 targetRotation;

    [HideInInspector]
    public bool isInInitialPosition = true;

    [Space(10)]
    public UnityEvent onInteract;

    [HideInInspector]
    public bool lockEvent;

    [Header("MATERIAL SWAP")]
    public Material default_Material; 
    public Material highlight_Material;


    [Header("FMOD SOUND")]
    [FMODUnity.EventRef]
    public string FMOD_Highlight_Event = "event:/SFX/Interactions/External/HighlightSFX"; // COLOCAR CAMINHO DEFAULT PARA EVENTO DE HIGHLIGHT 
    [FMODUnity.EventRef]
    public string FMOD_Interact_Event = "event:/SFX/Interactions/External/Momentum";  // COLOCAR CAMINHO DEFAULT PARA EVENTO DE INTERAÇÃO 

    private FMODUnity.StudioEventEmitter emitter;

    private FMOD.Studio.EventInstance highlight;
    private FMOD.Studio.EventInstance Interact;



    void Start()
    {
        //emitter = GameObject.Find("SFXEmitter").GetComponent<StudioEventEmitter>();

        //highlight = FMODUnity.RuntimeManager.CreateInstance(FMOD_Highlight_Event);
        //Interact = FMODUnity.RuntimeManager.CreateInstance(FMOD_Interact_Event);
    }

    public void DownLight()
    {
        //emitter.Stop();
        //highlight.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        //SOUND_CONTROL = false;
        //Debug.Log("DOWNLIGHT");



        if (default_Material != null)
            GetComponent<MeshRenderer>().material = default_Material;
    }

    bool SOUND_CONTROL ;

    public void HighLight()
    {
        if (FMOD_Highlight_Event != null && !SOUND_CONTROL)
        {
            //FMODUnity.RuntimeManager.PlayOneShot(FMOD_Highlight_Event,Vector3.zero);

            //emitter.Event = FMOD_Highlight_Event;
            //emitter.Play();

            //Debug.Log("HIGHLIGHT");
            //highlight.start();
            //SOUND_CONTROL = true;
        }

        if (highlight_Material != null)
            GetComponent<MeshRenderer>().material = highlight_Material;
    }

    public void Interaction()
    {
        if (FMOD_Interact_Event != null)
        {
            //emitter.Event = FMOD_Interact_Event;
            //emitter.Play();

            //Interact.start();
        }

        MoveObjectNow();

        if (lockEvent) return;      // Uma boolean de controle que desativa ao primeiro evento
        lockEvent = true;           // Caso queira que continue podendo lançar o evento
        onInteract.Invoke();        // Coloque esse script no evento e sette a variavel pra false.
    }

    public void MoveObjectNow()
    {
        isInInitialPosition = !isInInitialPosition;

        StopAllCoroutines();

        if (targetPosition == p_final && targetRotation == r_final)
        {
            targetPosition = p_Inicial;
            targetRotation = r_Inicial;
        }
        else
        {
            targetPosition = p_final;
            targetRotation = r_final;
        }

        StartCoroutine(Lerp());
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < speed)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, timeElapsed / speed);
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, targetRotation, timeElapsed / speed);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
