using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private CharacterController controlador;
    public float playerVelocity;
    public float gravidade;
    private float downForce;

    private bool lockState;
    private Visao head;

    [Header("ARMS ANIMATION")]
    public Animator arms;

    [Header("EVENTS")]
    public UnityEvent OnWalkStart;
    public UnityEvent OnWalkStop;

    void Start()
    {
        controlador = GetComponent<CharacterController>();

        head = transform.GetChild(1).GetComponent<Visao>(); // Pega o script visao do segundo filho - Rendering
    }

    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        if (lockState) return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            OnWalkStart.Invoke();

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            OnWalkStop.Invoke();

        Vector3 move = Vector3.zero;
        move += Input.GetAxis("Horizontal") * transform.right * playerVelocity;
        move += Input.GetAxis("Vertical") * transform.forward * playerVelocity;

        controlador.Move(move * Time.deltaTime);

        if (!controlador.isGrounded)
        {
            downForce += gravidade;
            controlador.Move(-downForce * Vector3.up * Time.deltaTime * 0.2f);
        }
        else downForce = 0;
    }

    public void TeleportTo(GameObject obj)
    {
        controlador.enabled = false;
        transform.position = obj.transform.position;
        transform.rotation = obj.transform.rotation;
        controlador.enabled = true;
    }

    public void LockPlayer()
    {
        lockState = true;
        head.LockHead();
    }
    public void UnlockPlayer()
    {
        lockState = false;
        head.UnlockHead();
    }

    public void playSnapShot(AnimatorOverrideController anim)
    {
        if(arms.runtimeAnimatorController != anim)
            arms.runtimeAnimatorController = anim;


        arms.SetTrigger("SnapShot");
    }

}
