using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RazaoEEmocao : MonoBehaviour
{
    public List<GameObject> Razao;
    public List<GameObject> Emocao;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))    // Quando o Player Clicar com o botão direito do mouse
        {
            razaoEEmocao();
        }
    }
    public void razaoEEmocao()
    {
        foreach (GameObject obj in Razao)
            switchState(obj);

        foreach (GameObject obj in Emocao)
            switchState(obj);
    }
    private void switchState(GameObject obj) => obj.SetActive(!obj.activeSelf);     // Inverte o estado do objeto em questão
}
