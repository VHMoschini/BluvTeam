using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class Save 
{
    public int currentLevel = 0;

    private String arquivo = "Salvo";
    public void SaveLevel()
    {
        var content = JsonUtility.ToJson(this, true);
        File.WriteAllText("Salvo1.txt", content);      
    }

    public void LoadLevel()
    {
        var content = File.ReadAllText("Salvo1.txt");
        var clound = JsonUtility.FromJson<Save>(content);

        currentLevel = clound.currentLevel;

    }

    public void NextLevel()
    {
        currentLevel++;
        SaveLevel();
    }

}
       
