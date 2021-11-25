using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WordsMover : MonoBehaviour
{
    private Player playerWordsMover;
    [SerializeField]
    private GameObject saidaWordsMover;

    public float posMaxima;
    public float velocidade;
    public bool maiorQue;
    //public float rebornZ;
    public float rebornX;

    public UnityEvent rebornPlayer;

    void Awake()
    {
        playerWordsMover = (Player)FindObjectOfType(typeof(Player));
    }
    void Update()
    {
        /*
         transform.Translate(0, 0, velocidade * Time.deltaTime);

         if (maiorQue && transform.position.z > posMaxima)
         {
             transform.position = new Vector3(transform.position.x, transform.position.y, rebornZ);
         }
         else if (!maiorQue && transform.position.z < posMaxima)
         {
             transform.position = new Vector3(transform.position.x, transform.position.y, rebornZ);
         }
        */

        transform.Translate(velocidade * Time.deltaTime, 0, 0);

        if (maiorQue && transform.position.x > posMaxima)
        {
            transform.position = new Vector3(rebornX, transform.position.y, transform.position.z );
        }
        else if (!maiorQue && transform.position.x < posMaxima)
        {
            transform.position = new Vector3(rebornX, transform.position.y, transform.position.z);
        }

        

    }
    public void TeleporteMethod()
    {
        playerWordsMover.TeleportTo(saidaWordsMover);
    }
}
