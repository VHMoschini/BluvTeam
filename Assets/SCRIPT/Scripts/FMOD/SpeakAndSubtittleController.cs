using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpeakAndSubtittleController : MonoBehaviour
{

    public bool startAway = false;   //Faz a fala ativar no start do objeto
    public TMP_Text sub;

    private bool isActive = false;
    private int current_index = 0;

    private FadeInWords wordControler;

    [Space(10)]
    [SerializeField] public List<AudioConfig> AUDIO_CONFIG = new List<AudioConfig>();

    void Start()
    {
        wordControler = sub.gameObject.GetComponent<FadeInWords>();

        foreach (AudioConfig i in AUDIO_CONFIG)
        {
            i.audioEvent = FMODUnity.RuntimeManager.CreateInstance(i.VoiceLine);
        }

        if (startAway == true) StartPlay(current_index);
    }

    void Update()
    {
        AudioConfig i = AUDIO_CONFIG[current_index];

        FMOD.Studio.PLAYBACK_STATE actualState;
        i.audioEvent.getPlaybackState(out actualState);

        if (isActive == true && actualState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            if (current_index < AUDIO_CONFIG.Count - 1)
            {
                i.OnEnd.Invoke();

                current_index++;
                StartPlay(current_index);
            }
            else
            {
                i.OnEnd.Invoke();

                isActive = false;
                current_index = 0;

                wordControler.FadeOut();
            }
        }
    }

    public void StartPlay(int index)
    {
        AudioConfig i = AUDIO_CONFIG[index];

        i.audioEvent.start();

        sub.text = i.Subtitle;
        if (!isActive) wordControler.FadeIn();

        isActive = true;
    }
}

[System.Serializable]
public class AudioConfig
{
    [SerializeField]
    [FMODUnity.EventRef] public string VoiceLine = "event:/Dublagem";

    [HideInInspector]
    public FMOD.Studio.EventInstance audioEvent;

    [TextArea] [SerializeField] public string Subtitle;

    [Space(10)]
    [SerializeField] public UnityEvent OnEnd;
}