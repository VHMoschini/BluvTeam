using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    public void ChangeScene(string nameScene)
    {
        var coroutine = LoadLevel(nameScene);
        StartCoroutine(coroutine);
    }
    public void FecharJogo()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(string nameScene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nameScene);
    }
}
