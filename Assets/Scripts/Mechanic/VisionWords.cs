using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisionWords : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float rightAngle;

    public UnityEvent FindWord;

    private float holdTime = 1;
    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = HoldCooldown(holdTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            var actualRotation = other.transform.eulerAngles.y;

            if (actualRotation > rightAngle - range && actualRotation < rightAngle + range)
            {
                StartCoroutine(coroutine);
            }
        }
    }

    IEnumerator HoldCooldown(float _holdTime)
    {
        yield return new WaitForSeconds(_holdTime);

        FindWord.Invoke();
    }
}

/*
 * TODO
 Comparar a distancia do jogador com esse objeto, e pegar a diferença e criar um glow que aumenta quanto mais perto
o jogador estiver
 */
