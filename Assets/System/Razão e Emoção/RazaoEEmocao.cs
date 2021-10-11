using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Interface externa da classe
//      => Bloquear a mudança para o jogador 
//      => Desbloquear a mudança para o jogador 
//      => Fazer a mudança de realidade

public class RazaoEEmocao : MonoBehaviour
{
    public List<GameObject> Razao;      // Objetos da razão
    public List<GameObject> Emocao;     // Objestos da emoção
    public bool lockState = true;       // Variavel de controle do jogador

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && lockState)    // Quando o Player Clicar com o botão direito do mouse e a mudança está desbloqueada
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
    public void LockChange() => lockState = false;      // Bloqueia a mudança da Razão e Emoção para o jogador
    public void UnlockChange() => lockState = true;     // Desbloqueia a mudança da Razão e Emoção para o jogador
}
