using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TriggerMoveDetection : MonoBehaviour
{
    public bool oneTimeTrigger;

    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MoveEver")
        {
            onTriggerEnter.Invoke();
            if (oneTimeTrigger) gameObject.SetActive(false);
        }

    }
}
