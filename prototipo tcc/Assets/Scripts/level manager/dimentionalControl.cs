using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimentionalControl : MonoBehaviour
{
    public GameObject sanityRealm;
    public GameObject emotionRealm;



    public bool canChange;

    public int dimention;

    // Start is called before the first frame update
    void Start()
    {
        sanityRealm.SetActive(true);
        emotionRealm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) ChangeDimention();

        if(canChange == true)
        {
            if(dimention == 0)
            {
                sanityRealm.SetActive(true);
                emotionRealm.SetActive(false);
            }
            
            if(dimention == 1)
            {
                sanityRealm.SetActive(false);
                emotionRealm.SetActive(true);
            }
        }
    }

    void ChangeDimention()
    {
        if (dimention == 0)
        {
            dimention = 1;
        }
        else dimention = 0;
    }
}
