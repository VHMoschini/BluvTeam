using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInWords : MonoBehaviour
{
    private TextMeshPro word;

    void OnEnable()
    {
        word = GetComponent<TextMeshPro>();
        word.color = new Color(255, 255, 255, 0);
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        while (word.color.a <= 1)
        {
            word.color = new Color(255, 255, 255, word.color.a + 0.05f);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
