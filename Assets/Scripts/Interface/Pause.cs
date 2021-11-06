using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pause;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            pause.transform.GetChild(0).gameObject.SetActive(true);
            pause.transform.GetChild(1).gameObject.SetActive(false);

            OpenClosePause(); // Abre/Fecha o objeto de pause e ativa/desativa o cursor
        }
    }
    public void OpenClosePause()
    {
        var actualState = pause.activeSelf;

        Utils.ChangeCursorState(!actualState);
        pause.SetActive(!actualState);
        Time.timeScale = pause.activeSelf ? 0 : 1;
    }

    public void VoltarAoMenu()
    {
        // Volta ao estado normal, DEFAULT
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");
    }
}