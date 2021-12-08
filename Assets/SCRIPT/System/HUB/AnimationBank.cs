using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationBank : MonoBehaviour
{
    public AnimationEvent blink;
    public Animator animator;

    public List<Animation_Item> ANIMATIONS = new List<Animation_Item>();

    private Transform avatar_transform;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClip current_clip;

    void Awake()
    {
        blink.OnAnimationTrigger.AddListener(swapAnimation);

        avatar_transform = animator.gameObject.GetComponent<Transform>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        swapAnimation();

        blink.transform.parent.gameObject.SetActive(false);
    }

    public void ChangeAnimations() => Blink();

    private void swapAnimation()
    {
        Animation_Item i = new Animation_Item();
        if (current_clip == null)
            i = ANIMATIONS[Random.Range(0, ANIMATIONS.Count)];

        else
            do
            {
                i = ANIMATIONS[Random.Range(0, ANIMATIONS.Count)];
            } while (i.Clip == current_clip && ANIMATIONS.Count > 1);

        current_clip = i.Clip;
        avatar_transform.position = i.Position.position;
        avatar_transform.rotation = i.Position.rotation;

        animatorOverrideController["Idle"] = i.Clip;
    }

    private void Blink()
    {
        blink.transform.parent.gameObject.SetActive(false);
        blink.transform.parent.gameObject.SetActive(true);
    }
}

[System.Serializable]
public class Animation_Item
{
    [SerializeField] public AnimationClip Clip;
    [SerializeField] public Transform Position;
}
