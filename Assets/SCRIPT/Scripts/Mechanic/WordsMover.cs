using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsMover : MonoBehaviour
{
    public float posMaxima;
    public float velocidade;
    public bool maiorQue;
    public float rebornZ;

    void Update()
    {
        transform.Translate(0, 0, velocidade * Time.deltaTime);

        if (maiorQue && transform.position.z > posMaxima)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rebornZ);
        }
        else if (!maiorQue && transform.position.z < posMaxima)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rebornZ);
        }
    }
}
