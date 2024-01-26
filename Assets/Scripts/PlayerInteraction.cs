using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


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





    [Header("Liste des boutons par zone")]
    [SerializeField] private ObjetInteractable[] boutons;
    [SerializeField] private ObjetInteractable[] boutonsP0;
    [SerializeField] private ObjetInteractable[] boutonsP1;
   



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
      


        // si on appuie sur les bons boutons, la porte s'ouvre

        // porte tuto
        if (boutons[0].isOnUse) { ManageMyEvents.NotifyTutoDoor(); }



        // porte facile
        if (!boutonsP0[0].isOnUse && boutonsP0[1].isOnUse && boutonsP0[2].isOnUse && !boutonsP0[3].isOnUse) { ManageMyEvents.NotifyPorteFacile(); }  else {  ManageMyEvents.NotifyBadAnswer(); }


        // plus long if de ma vie : *-- **- **- *--
        // porte difficile
        if (!boutonsP1[0].isOnUse && boutonsP1[1].isOnUse && !boutonsP1[2].isOnUse &&

            !boutonsP1[3].isOnUse && boutonsP1[4].isOnUse && !boutonsP1[5].isOnUse &&

            !boutonsP1[6].isOnUse && boutonsP1[7].isOnUse && !boutonsP1[8].isOnUse &&

            !boutonsP1[9].isOnUse && boutonsP1[10].isOnUse && !boutonsP1[11].isOnUse) 

            { ManageMyEvents.NotifySolutionFound(); }
        else {  ManageMyEvents.NotifyBadAnswer(); }






    }
}
