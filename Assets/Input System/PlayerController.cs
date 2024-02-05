using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


/// <summary>
///  Ce script permet de contrôler le Player  : mouvements, animation, et inputs
///  Sources: 
///  - Guide du module Stealth
///  - vidéo : https://youtu.be/SeBEvM2zMpY?feature=shared
///  - doc Unity
///  
/// </summary>



[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
   

    #region VARIABLES

    private Animator animator;
    private Vector2 animationBlend;
    private Vector2 animationVelocity;
    public float animationSmoothTime = 0.1f;


    private CharacterController controller;


    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Transform camera;
    
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction lookAction;
    //private InputAction hitAction;
    private InputAction interagirAction;

    [SerializeField]
    private float moveSpeed = 2.0f;

    

    [SerializeField]
    private float rotationSpeed = 2.0f;

   

    [SerializeField]
    private float gravityValue = -9.81f;



    [SerializeField]
    bool isInteracted = false;



    private FloorDetection m_floordetection;
    [SerializeField] private float offset = 1f;




    #endregion


    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        camera = Camera.main.transform;


        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        //hitAction = playerInput.actions["Hit"];
        interagirAction = playerInput.actions["Interagir"];

        animator = GetComponentInChildren<Animator>();

        m_floordetection = GetComponentInChildren<FloorDetection>();

    }

    void Update()
    {
        Interaction();
       

        // Marche Basique
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector2 input = moveAction.ReadValue<Vector2>();
        animationBlend = Vector2.SmoothDamp(animationBlend, input, ref animationVelocity, animationSmoothTime);

        Vector3 move = new Vector3(animationBlend.x, 0, animationBlend.y);

        // Caméra
        move = move.x * camera.transform.right.normalized + move.z * camera.transform.forward.normalized;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * moveSpeed);

        // Animator
        animator.SetFloat("moveX", animationBlend.x);
        animator.SetFloat("moveZ", animationBlend.y);


        

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

       

        // Rotation
        float targetAngles = camera.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngles, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        // Animation



        //Floor detection
        

    }

    private void Interaction()
    {
       /* if(hitAction.triggered && isInteracted)
        {
            Debug.Log("frapper");
        }*/

     /*   if (interagirAction.triggered)
        {
            Debug.Log("bouton interagir");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            isInteracted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interaction"))
        {
            isInteracted = false;
        }


    }

    // obsolète:
    private void StickToGround()
    {
        Vector3 averagePosition = m_floordetection.AverageHeight();
        controller.center = new Vector3(controller.center.x, averagePosition.y, controller.center.x) ;

        Debug.Log(averagePosition);
    }
}