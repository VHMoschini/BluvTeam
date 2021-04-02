using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractions : MonoBehaviour
{
    public int books = 0;

    public bool hasBook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (books > 0) hasBook = true;
        else hasBook = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BookCollect")
        {
            books++;
            Destroy(other.gameObject);
        }
    }
}
