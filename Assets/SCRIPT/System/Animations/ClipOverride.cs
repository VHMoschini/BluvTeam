using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipOverride : MonoBehaviour
{
    public AnimationClip clip;
    private Animator animator;
    private AnimatorOverrideController animatorOverrideController;

    void Start()
    {
        animator = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        animatorOverrideController["Idle"] = clip;
    }
}
