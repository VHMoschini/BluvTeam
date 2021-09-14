using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findwords : MonoBehaviour
{
  public float range = 60;
  public string nameWordLeft;
  public string nameWordRight;

  public Vector3 rangeLimit;

    void Update()
    {
        Ray raioL = Camera.main.ScreenPointToRay(Input.mousePosition + rangeLimit);
        Ray raioR = Camera.main.ScreenPointToRay(Input.mousePosition - rangeLimit);

        // Debug.DrawRay(raioL.origin + rangeLimit, (raioL.direction + rangeLimit) * range,  Color.green);
        // Debug.DrawRay(raioR.origin -rangeLimit, (raioR.direction - rangeLimit)  * range , Color.blue);
        Debug.DrawRay(raioL.origin , raioL.direction  * range,  Color.green);
        Debug.DrawRay(raioR.origin, raioR.direction   * range , Color.blue);

        RaycastHit hit;
        RaycastHit hit2;
        
        // if (Physics.Raycast(raioR.origin - rangeLimit ,raioR.direction + rangeLimit, out hit2, range)){
        //         nameWordRight = hit2.transform.name;
        //     }

        //  if (Physics.Raycast(raioL.origin - rangeLimit ,raioL.direction + rangeLimit, out hit, range)){
        //         Debug.Log(hit.transform.name + hit.transform.gameObject.layer);
        //         nameWordLeft = hit.transform.name;
        //     }

            if (Physics.Raycast(raioL.origin - rangeLimit ,raioL.direction + rangeLimit, out hit, range *3) && Physics.Raycast(raioR.origin - rangeLimit ,raioR.direction + rangeLimit, out hit2, range *3)){
                
                
                Debug.Log(hit.transform.name + hit.transform.gameObject.layer);
                Debug.Log(hit2.transform.name + hit2.transform.gameObject.layer);

                nameWordLeft = hit.transform.name;
                nameWordRight = hit2.transform.name;

            }
    }
}
