using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent OnAnimationTrigger ;
    public GameObject parentObject;

    public void LaunchEvent() => OnAnimationTrigger.Invoke();

    public void DisableAnimation() => parentObject.SetActive(false);
}
