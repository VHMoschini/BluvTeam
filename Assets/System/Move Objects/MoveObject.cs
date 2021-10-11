using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour, IInteragivel
{
    [Header("Transform Inicial")]
    [SerializeField] public Vector3 p_Inicial = Vector3.zero;
    [SerializeField] public Vector3 r_Inicial = Vector3.zero;

    [Header("Transform Final")]
    [SerializeField] public Vector3 p_final = Vector3.zero;
    [SerializeField] public Vector3 r_final = Vector3.zero;

    [Space(10)]

    [SerializeField] float speed = 200;

    private Vector3 targetPosition;
    private Vector3 targetRotation;

    public void DownLight()
    {
    }

    public void HighLight()
    {
    }

    public void Interaction()
    {
        StopAllCoroutines();

        if (targetPosition == p_final && targetRotation == r_final)
        {
            targetPosition = p_Inicial;
            targetRotation = r_Inicial;
        }
        else
        {
            targetPosition = p_final;
            targetRotation = r_final;
        }

        StartCoroutine(Lerp());
    }

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < speed)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, timeElapsed / speed);
            transform.localEulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, timeElapsed / speed);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
