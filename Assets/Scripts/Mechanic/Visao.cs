using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visao : MonoBehaviour
{

    [Header("Camera Control")]
    public Slider sensibilitySlider;
    private float mouseSensitivity;
    [Space(10)]
    public Transform playerBody;

    float xRotation = 0f;

    [Header("RayCast")]
    IInteragivel interacao;

    private Ray ray;
    private RaycastHit hit;

    private float range = 2.5f;
    public GameObject interactionHint;

    [Header("Razões e Emoções")]
    public List<GameObject> Razao;
    public List<GameObject> Emocao;

    private void Start()
    {
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnEnable()
    {
        mouseSensitivity = PlayerPrefs.GetFloat(Constantes.SENSIBILITY_SAVE, 15f);
        sensibilitySlider.value = mouseSensitivity;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(Constantes.SENSIBILITY_SAVE, mouseSensitivity);
    }

    #region [ Razão e Emoção ]

    private void Update()
    {
        PlayerVision();
        RayCast();

    }

    public void razaoEEmocao()
    {
        foreach (GameObject obj in Razao)
            switchState(obj);

        foreach (GameObject obj in Emocao)
            switchState(obj);
    }

    private void switchState(GameObject obj) => obj.SetActive(!obj.activeSelf);

    #endregion

    #region [ Camera Control ]
    private void PlayerVision()
    {
        float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivity * 20) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * 20) * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    #endregion

    #region [ RayCast ]
    private void RayCast()
    {

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.yellow); // Usado apenas para ver a direção que o jogador está olhando na Aba Scene

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (interacao != null)
        {
            interacao.DownLight();
            interactionHint.SetActive(false);
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            interacao = hit.transform.GetComponent<IInteragivel>();
            if (interacao != null)
            {
                if (!interacao.interagivel) return;

                interacao.HighLight();
                interactionHint.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                    interacao.Interaction();
            }
        }

    }
    #endregion

    public void SensibilityController(float sensibility)
    {
        mouseSensitivity = sensibility;
    }
}
