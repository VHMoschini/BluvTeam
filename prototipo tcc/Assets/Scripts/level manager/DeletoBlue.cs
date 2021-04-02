using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletoBlue : MonoBehaviour
{
    public GameObject portal;

    public string Tag = "Player";
 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tag)
        {
            portal.SetActive(false);
        }
    }
}
