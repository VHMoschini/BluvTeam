using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderControl : MonoBehaviour
{
    FMOD.Studio.EventInstance SFXVolumeTest;
    FMOD.Studio.EventInstance VoiceVolumeTest;

    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    FMOD.Studio.Bus Voice;

    public float MasterVolume = 1.0f;
    public float MusicVolume = 1.0f;
    public float SFXVolume = 1.0f;
    public float VoiceVolume = 1.0f;

    bool menuEnabled = false;

    //Linkando as variáveis do código com os faders do FMOD e tocando o som de referência
    private void Awake()
    {       

        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Voice = FMODUnity.RuntimeManager.GetBus("bus:/Master/Voice");

        SFXVolumeTest = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXtest");
    }

    //Atualizando o volume no FMOD
    void Update()
    {
        Master.setVolume(MasterVolume); 
        Music.setVolume(MusicVolume); 
        SFX.setVolume(SFXVolume);
        Voice.setVolume(VoiceVolume);

    }

    //Controles para os sliders da interface
    public void MasterVolumeLevel(float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }
    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }
    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE sfxPlayback;
        SFXVolumeTest.getPlaybackState(out sfxPlayback);

        if(sfxPlayback == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            SFXVolumeTest.start();
        }
    }
    public void VoiceVolumeLevel(float newVoiceVolume)
    {
        VoiceVolume = newVoiceVolume;

        FMOD.Studio.PLAYBACK_STATE voicePlayback;
        SFXVolumeTest.getPlaybackState(out voicePlayback);

        if (voicePlayback == FMOD.Studio.PLAYBACK_STATE.STOPPED)
        {
            VoiceVolumeTest.start();
        }
    }
}
