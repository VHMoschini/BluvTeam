using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<scriptable> MechanicPos = new List<scriptable>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(scriptable i in MechanicPos)
        {
            /*
             * -> Criar um objeto
             * -> Posicionar o objeto no i.position
             * -> Criar o box colider
             * -> settar o colisor como trigger
             * -> Vai alterar o tamanho pra i.boxSize
             * 
             * -> Criar o script "VisionWord"
             * -> vai atribuir o angulo
             * -> Atribuir o Treshold
             */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
