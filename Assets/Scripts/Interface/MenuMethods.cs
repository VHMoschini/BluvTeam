using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
   public void ChangeScene (string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
       public void FecharJogo()
    {
        Application.Quit();
    }
}
