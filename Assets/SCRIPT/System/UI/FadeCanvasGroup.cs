using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvasGroup : MonoBehaviour
{
    private CanvasGroup group;

    public bool OnStart = true;

    [Header ("DELAY TIME")]
    public float IntroDelay = 1;

    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    void OnEnable()
    {
        if (!OnStart) return;

        group.alpha = 0;
        StartCoroutine(fadeIn_coroutine(IntroDelay));
    }
    public void FadeIn() => StartCoroutine(fadeIn_coroutine(IntroDelay));
    public void FadeOut() => StartCoroutine(fadeOut_coroutine());

    IEnumerator fadeIn_coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (group.alpha <= 1)
        {
            group.alpha += 0.05f;
            yield return new WaitForSeconds(0.03f);
        }
    }

    IEnumerator fadeOut_coroutine()
    {
        while (group.alpha >= 0)
        {
            group.alpha -= 0.05f;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
