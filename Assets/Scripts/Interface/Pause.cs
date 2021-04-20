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
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            OpenClosePause(); // Abre/Fecha o objeto de pause e ativa/desativa o cursor
        }
    }
    public void OpenClosePause(){
        var actualState = pause.activeSelf;

        Utils.ChangeCursorState(!actualState);
        pause.SetActive(!actualState);
        Time.timeScale = pause.activeSelf ? 0 : 1;
    }

       public void VoltarAoMenu ()
    {
        // Volta ao estado normal, DEFAULT
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");
    }
}