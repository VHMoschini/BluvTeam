using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// INTERFACE DA CLASSE
// FadeIn
// FadeOut
// Transition
public class SubtitleHandler : MonoBehaviour
{
    public List<string> Falas = new List<string>();     // Armazena todas as falas que serão exibidas no dialogo
    private TextMeshProUGUI textToUse;

    private void Start() => textToUse = GetComponent<TextMeshProUGUI>(); // Pega o component Text

    // INTERFACE DA CLASSE
    public void FadeInText(float timeSpeed = -1.0f) => StartCoroutine(FadeInText(timeSpeed, textToUse));
    public void Transition() => StartCoroutine(_transition(textToUse));
    public void FadeOutText(float timeSpeed = -1.0f) => StartCoroutine(FadeOutText(timeSpeed, textToUse));


    // CORROTINAS DE TRANSIÇÕES
    public IEnumerator _transition(TextMeshProUGUI textToUse)
    {
        yield return StartCoroutine(FadeInText(1f, textToUse));
        // Troca o texto pelo próximo!
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeOutText(1f, textToUse));
    }
    private IEnumerator FadeInText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
    private IEnumerator FadeOutText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }

}
