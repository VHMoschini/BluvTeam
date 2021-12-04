using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteSave : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        var s = (HUBStatus)PlayerPrefs.GetInt(Constantes.HUB_STATE);
        text.text = s.ToString();
    }

    void Update()
    {
        
    }
}
