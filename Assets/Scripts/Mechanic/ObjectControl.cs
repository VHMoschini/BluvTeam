using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public Vector3 objetivo;
    private Vector3 InitialPosition;
    private Vector3 atual;
    
    void Start()
    {
        InitialPosition = transform.position;
        atual = InitialPosition;
    }
    void Update(){

        transform.position = Vector3.Lerp(transform.position,atual, 0.1f);      
    }
    public void Move(){

        if(atual != objetivo){
            atual = objetivo;
        }
        else 
        atual = InitialPosition;
    }
}
