using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desespero : MonoBehaviour
{

    public SpeakAndSubtittleController s;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            s.StartPlay();
        }
    }
}
