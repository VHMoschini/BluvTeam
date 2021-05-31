using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisionWords : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float rightAngle;
    public UnityEvent FindWord;

    private void OnTriggerStay(Collider other)
    {
        // Enquanto o jogador estiver dentro do colisor e olhando dentro da folga de angulo, invoca o trigger
        if (other.tag == "Player")
        {


            var actualRotation = other.transform.eulerAngles.y;
            Debug.Log(actualRotation);
            Debug.Log("Range: " + (rightAngle - range) + " - " + (rightAngle + range));

            if (actualRotation > rightAngle - range && actualRotation < rightAngle + range)
            {
                FindWord.Invoke();
            }
        }
    }
}
