using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMover : MonoBehaviour
{
    public float moveForce;
    public float maxValue;

    void Update()
    {
        if (transform.position.y < maxValue)
            transform.position = new Vector3(transform.position.x, transform.position.y + (moveForce * Time.deltaTime), transform.position.z);
    }
}
