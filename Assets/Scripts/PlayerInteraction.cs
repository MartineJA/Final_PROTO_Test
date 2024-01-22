using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Script d'après:
///  - guide du module Audio
///  - doc Raycast Unity : https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
///  - vidéo : https://youtu.be/ZNiEbRL85Vc?feature=shared
///  
/// Permet de lancer une interaction en fonction d'un Raycast situé sur l'objet Player
/// 
/// </summary>
/// 
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private float m_maxDistance;

    [SerializeField]
    private LayerMask m_layerMask;

    IUsable m_target;


    PlayerInput m_input;
    InputAction m_interagirAction;

    RaycastHit hit;

    Camera cam;


    //[SerializeField] private Buttons button; obsolète


    [SerializeField] private ObjetInteractable[] boutons;



    // Start is called before the first frame update
    void Awake()
    {   
        m_input = GetComponent<PlayerInput>();
        m_interagirAction = m_input.actions["Interagir"];
        cam = Camera.main;
    }


    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    }
    private void OnEnable()
    {
        m_interagirAction.performed += Interaction;
    }

    private void OnDisable() 
    {
        m_interagirAction.performed -= Interaction;
    }


    void Interaction(InputAction.CallbackContext callbackContext)
    {
        
       
        if (!Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, m_maxDistance, m_layerMask)) return;
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward)* hit.distance, Color.yellow);

        if (!hit.transform.TryGetComponent(out IUsable interactable)) return;
        interactable.Use();
        Debug.Log("Interaction");


        ManageMyEvents.NotifyButtonPushed();
        //button.number += 1; obsolète




        // si on appuie sur les bons boutons, la porte s'ouvre
        if (boutons[0].isOnUse && boutons[2].isOnUse && !boutons[1].isOnUse) { ManageMyEvents.NotifySolutionFound(); }
        if (boutons[3].isOnUse) { ManageMyEvents.NotifySolutionFound(); }


    }
}
