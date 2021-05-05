using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controlador;
    public float playerVelocity;
    public float gravidade;
    private float downForce;
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        Vector3 move = Vector3.zero;
        move += Input.GetAxis("Horizontal") * transform.right * playerVelocity;
        move += Input.GetAxis("Vertical") * transform.forward * playerVelocity;

        controlador.Move(move * Time.deltaTime);


        if (!controlador.isGrounded)
        {
            downForce += gravidade;
            controlador.Move(-downForce * Vector3.up * Time.deltaTime);
        }
        else downForce = 0;
    }

    public void TeleportTo(GameObject obj)
    {
        controlador.enabled = false;
        transform.position = obj.transform.position;
        controlador.enabled = true;
    }
}
