using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDetection : MonoBehaviour
{
    public bool oneTimeTrigger;

    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onTriggerEnter.Invoke();
            if (oneTimeTrigger) gameObject.SetActive(false);
        }

    }
}


