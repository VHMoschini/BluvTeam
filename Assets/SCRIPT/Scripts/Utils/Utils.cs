using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // Função que da um swipe em dois objetos, pode ser usado acessando utils.SwipeObject
    public static Action<GameObject, GameObject> SwipeObject = (GameObject Atual, GameObject Novo) =>
     {
         Atual.SetActive(false);
         Novo.SetActive(true);
     };

    public static void ChangeCursorState(bool state)
    {
        if (state)
            Cursor.lockState = CursorLockMode.Confined;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
}
