using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{

    public int total;
    private int atual;
    public UnityEvent GetAll;
    public Text contadorDisplay;

    void Update()
    {
        if (contadorDisplay != null)
        {
            if (contadorDisplay.gameObject.activeSelf)
            {
                contadorDisplay.text = atual + "/" + total;
            }
        }

        if (atual >= total)
        {
            GetAll.Invoke();
        }
    }

    public void incremento()
    {
        atual++;
    }
}
