using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelProgress : MonoBehaviour
{
    public GameObject FinalDoorA;
    public GameObject FinalDoorB;

    public GameObject Books1;
    public GameObject Books2;

    public GameObject Part1;

    public bool isComplete;
    public bool book1ready;
    public bool book2ready;


    // Start is called before the first frame update
    void Start()
    {
        FinalDoorA.SetActive(false);
        FinalDoorB.SetActive(false);
        Part1.SetActive(false);
        isComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        book1ready = Books1.GetComponent<objectChange>().isSet;   
        book2ready = Books2.GetComponent<objectChange>().isSet;

        if (book1ready == true && book2ready == true)
        {
            FinalDoorA.SetActive(true);
            FinalDoorB.SetActive(true);

            Part1.SetActive(true);
        }
    }
}
