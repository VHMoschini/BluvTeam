using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInWords : MonoBehaviour
{
    private TMP_Text word;

    public bool OnStart = true;

    private void Awake()
    {
        word = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        if (!OnStart) return;

        word.color = new Color(255, 255, 255, 0);
        StartCoroutine(fadeIn_coroutine());
    }

    IEnumerator fadeIn_coroutine()
    {
        while (word.color.a <= 1)
        {
            word.color = new Color(255, 255, 255, word.color.a + 0.05f);
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void FadeIn() => StartCoroutine(fadeIn_coroutine());
    public void FadeOut() => StartCoroutine(fadeOut_coroutine());

    IEnumerator fadeOut_coroutine()
    {
        while (word.color.a >= 0)
        {
            word.color = new Color(255, 255, 255, word.color.a - 0.05f);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
