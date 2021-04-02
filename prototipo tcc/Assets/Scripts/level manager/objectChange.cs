using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectChange : MonoBehaviour
{
    public GameObject player;

    public GameObject Book1;
    public GameObject Book2;
    public GameObject Book3;

    public Material defaultMat;
    public Material invisible;
    public Material ghost;
    public Material currentMat;

    public bool isSet;
    public bool isHighlighted = false;
    public bool isPlayerNear = false;
    public bool playerHasBooks;

    public int placedBooks = 0;
    public int playerBooks = 0;

    public Collider trigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerBooks = player.GetComponent<playerInteractions>().books;
        playerHasBooks = player.GetComponent<playerInteractions>().hasBook;

        if(placedBooks == 3)
        {
            isSet = true;
            trigger.enabled = false;
        }

        if (isSet != true)
        {
            if (isHighlighted == true)
            {
                currentMat = ghost;

                if (Input.GetMouseButtonDown(0))
                {
                    AddBook();
                    
                }

            }
            else currentMat = invisible;
        }

        if(placedBooks == 0)
        {
            Book1.GetComponent<Renderer>().material = currentMat;
            Book2.GetComponent<Renderer>().material = currentMat;
            Book3.GetComponent<Renderer>().material = currentMat;
        } else if(placedBooks == 1)
        {
            Book1.GetComponent<Renderer>().material = defaultMat;
            Book2.GetComponent<Renderer>().material = currentMat;
            Book3.GetComponent<Renderer>().material = currentMat;
        } else if(placedBooks == 2)
        {
            Book1.GetComponent<Renderer>().material = defaultMat;
            Book2.GetComponent<Renderer>().material = defaultMat;
            Book3.GetComponent<Renderer>().material = currentMat;
        } else if(placedBooks == 3)
        {
            Book1.GetComponent<Renderer>().material = defaultMat;
            Book2.GetComponent<Renderer>().material = defaultMat;
            Book3.GetComponent<Renderer>().material = defaultMat;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //playerBooks = other.gameObject.GetComponent<playerInteractions>().books;
            Debug.Log("player entrou");
            isHighlighted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isHighlighted = false;
        Debug.Log("player saiu");
    }

    void AddBook()
    {
        if (placedBooks < 3 && playerBooks > 0)
        {
            Debug.Log("player ativou");

            placedBooks++;
            player.GetComponent<playerInteractions>().books--;
        }
    }
}
