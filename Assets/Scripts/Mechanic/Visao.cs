using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    IInteragivel interacao;
    private Ray ray;
    private RaycastHit hit;

    private void Start(){
        transform.localRotation = Quaternion.Euler(Vector3.up);
    }

    private void Update()
    {
        PlayerVision();

        RayCast();

    }

    private void PlayerVision()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void RayCast()
    {
        Debug.DrawRay(transform.position, Vector3.forward, Color.green);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) // Corrigir a distancia que o raycast percorre
        {
            if (hit.transform.GetComponent<IInteragivel>() == null && interacao != null)
            {
                interacao.DownLight();
                return;
            }
            interacao = hit.transform.GetComponent<IInteragivel>();
            if (interacao != null)
            {
                interacao.HighLight();
                if (Input.GetMouseButtonDown(0))
                    interacao.Interaction();
            }
        }
    }
}
