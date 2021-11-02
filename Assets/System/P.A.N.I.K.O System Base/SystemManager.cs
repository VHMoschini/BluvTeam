using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public HUBStatus nextHUBState;

    public void ChangeHUBState()
    {
        PlayerPrefs.SetString(Constantes.HUB_STATE, nextHUBState.ToString());
    }

}
