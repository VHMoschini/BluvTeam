using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HUB : MonoBehaviour
{
    [Space(10)]
    public List<HUB_Status_Item> DIALOGS = new List<HUB_Status_Item>();

    private HUBStatus actual_status;

    private void Awake()
    {
        actual_status = (HUBStatus)PlayerPrefs.GetInt(Constantes.HUB_STATE);
    }

    private void Start()
    {
        PlayCutscene();
    }

    public void PlayCutscene()
    {
        HUB_Status_Item i = DIALOGS.Find(h => h.HUB_Status == actual_status);

        i.Dialog.StartPlay();
    }
}

[System.Serializable]
public class HUB_Status_Item
{
    [SerializeField] public HUBStatus HUB_Status;
    [SerializeField] public SpeakAndSubtittleController Dialog;
}