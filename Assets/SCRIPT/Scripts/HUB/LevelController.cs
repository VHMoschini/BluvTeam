using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LevelController : MonoBehaviour
{

    public int i;
    public Save save;

    public GameObject[] andares;


    public void Start()
    {
        save = new Save();

        save.LoadLevel();

        Carregamento();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Reset();
        }
    }
    public void Carregamento()
    {
         
         for (i = 0; i <= save.currentLevel && i <= andares.Length; i++)
           {
            andares[i].SetActive(true);
           }
    }

    public void NextLevel()
    {
        save.NextLevel();
        //Carregamento();
    }

    public void Reset()
    {
        save.currentLevel = 0;
        save.SaveLevel();
    }
}
