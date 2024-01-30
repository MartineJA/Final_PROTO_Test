using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
using System.Linq;

/// <summary>
/// Script d'apr�s:
///  - guide du module Audio
///  - doc Raycast Unity : https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
///  - vid�o : https://youtu.be/ZNiEbRL85Vc?feature=shared
///  
/// Permet de lancer une interaction en fonction d'un Raycast situ� sur l'objet Player
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


    bool porte2B = false;
    bool porte2A = false;


    [Header("Liste des boutons par pi�ce")]
    [SerializeField] private ObjetInteractable boutons;
    [SerializeField] private ObjetInteractable[] boutonsP0;   
    [SerializeField] private ObjetInteractable[] boutonsP1;

    [SerializeField] private ObjetInteractable[] boutonsP2a;
    [SerializeField] private ObjetInteractable[] boutonsP2b;


    [SerializeField] private SoundTrigger[] sound;




    // Start is called before the first frame update
    void Awake()
    {   
        m_input = GetComponent<PlayerInput>();
        m_interagirAction = m_input.actions["Interagir"];
        cam = Camera.main;
        foreach(SoundTrigger s in sound) { GetComponentInChildren<AudioSource>(); }
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
        //Debug.Log("Interaction");

        ManageMyEvents.NotifyButtonPushed();
        

        // ********************** si on appuie sur les bons boutons, la porte s'ouvre

        // Porte tuto
        if (boutons.isOnUse) { ManageMyEvents.NotifyTutoDoor(); } 

        // Porte facile
        if (!boutonsP0[0].isOnUse && boutonsP0[1].isOnUse && boutonsP0[2].isOnUse && !boutonsP0[3].isOnUse) { ManageMyEvents.NotifyPorteFacile(); }




        PorteMoyenne();
        PorteDifficileA();
       

       





        // plus long if de ma vie : *-- **- **- *--
        // porte difficile
        /*  if (!boutonsP2[0].isOnUse && boutonsP2[1].isOnUse && !boutonsP2[2].isOnUse &&

              !boutonsP2[3].isOnUse && boutonsP2[4].isOnUse && !boutonsP2[5].isOnUse &&

              !boutonsP2[6].isOnUse && boutonsP2[7].isOnUse && !boutonsP2[8].isOnUse &&

              !boutonsP2[9].isOnUse && boutonsP2[10].isOnUse && !boutonsP2[11].isOnUse) 

              { ManageMyEvents.NotifySolutionFound(); }*/



    }

    

   
    void PorteMoyenne()
    {
        if (sound[0].hasBeenListened && sound[1].hasBeenListened)
        {
            Debug.Log("les sons ont �t� entendus");
            

            if (boutonsP1[0].isOnUse) { Debug.Log("sound01"); sound[0].m_AudioSource.Play(); }
            if (boutonsP1[1].isOnUse) { Debug.Log("sound02"); sound[1].m_AudioSource.Play(); }



            if (boutonsP1[0].isOnUse && boutonsP1[1].isOnUse)
               { ManageMyEvents.NotifyPorteMoyenne(); }

        }
        else Debug.Log("vous devriez �couter autour de vous");

    }


    void PorteDifficileA()
    {



        // premi�re ligne:
        if (!boutonsP2a[0].isOnUse && boutonsP2a[1].isOnUse && !boutonsP2a[2].isOnUse && boutonsP2a[3].isOnUse) porte2A = true;
        // premi�re ligne:
        if (!boutonsP2b[0].isOnUse && !boutonsP2b[1].isOnUse && boutonsP2b[2].isOnUse && boutonsP2b[3].isOnUse) porte2B = true;

        if (porte2A && porte2B) { ManageMyEvents.NotifySolutionFound(); Debug.Log("porte ouvert"); }
        



    }

      void PorteDifficileB()
    {
        

        if (sound[2].hasBeenListened && sound[3].hasBeenListened)
        {
            if (boutonsP2b[3].isOnUse) { Debug.Log("sound01"); sound[2].m_AudioSource.Play(); }
            if (boutonsP2b[2].isOnUse) { Debug.Log("sound02"); sound[3].m_AudioSource.Play(); }


            if (boutonsP2b[3].isOnUse && boutonsP2b[2].isOnUse && !boutonsP2b[0].isOnUse && !boutonsP2b[1].isOnUse) 
            porte2B = true;

        }
    }




}
