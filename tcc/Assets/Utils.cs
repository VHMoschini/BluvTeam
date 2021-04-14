using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // Função que da um swipe em dois objetos, pode ser usado acessasndo utils.SwipeObject
    public static Action<GameObject,GameObject> SwipeObject = (GameObject Atual, GameObject Novo) =>
    {
        Atual.SetActive(false);
        Novo.SetActive(true);
    };
}
