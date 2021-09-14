using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float range = 60;
    private ObjectControl objeto; 
    void Update()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * range);
       
        RaycastHit hit;

        if (Physics.Raycast(raio, out hit, range)){
            if(hit.transform.GetComponent<ObjectControl>()){
                
                objeto = hit.transform.GetComponent<ObjectControl>();

                if (Input.GetMouseButtonDown(0))
                    {
                        objeto.Move();
                    }
            }
        }
    }
}
