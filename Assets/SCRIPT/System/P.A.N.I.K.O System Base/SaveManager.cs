using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //[Header("ITEM COLECIONAVEL")]
    //[Tooltip("Item coletavel da fase em questão")]
    //public Colectable Coletavel;

    public HUBStatus NextState;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UPDATE_GAME_STATUS()
    {
        PlayerPrefs.SetInt(Constantes.HUB_STATE, (int)NextState);
    }

    public void SAVE_COLECIONAVEL(Colectable Coletavel)
    {
        const string EMPTY_STRING = "EMPTY";

        string adiquiridos_raw = PlayerPrefs.GetString(Constantes.COLECTABLE_LIST,EMPTY_STRING);

        if (adiquiridos_raw == EMPTY_STRING)
        {
            PlayerPrefs.SetString(Constantes.COLECTABLE_LIST, Coletavel.ToString());
            return;
        }

        List<string> adiquiridos = new List<string>();
        adiquiridos.AddRange(adiquiridos_raw.Split(','));

        if (adiquiridos.Contains(Coletavel.ToString())) return;

        adiquiridos.Add(Coletavel.ToString());

        string coletavel_list = "";

        foreach(string obj in adiquiridos)
        {
            coletavel_list += "," + obj;
        }

        coletavel_list.Remove(0);

        PlayerPrefs.SetString(Constantes.COLECTABLE_LIST, coletavel_list);
    }

}
