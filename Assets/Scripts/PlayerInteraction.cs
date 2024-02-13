using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

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

    public GameObject volume;
    public GameObject cube;


    PlayerInput m_input;
    InputAction m_interagirAction;
    InputAction m_InventaireAction;

    DefaultInputActions m_inputUI;
    InputAction m_submitAction;

    InputAction m_changeView;

    RaycastHit hit;

    Camera cam;

    public GameObject inventoryUI;
    public GameObject IRcam;

    [SerializeField]
    private Item[] item;

    //BoxCollider[] boxCollider;



    bool porte2B = false;
    bool porte2A = false;
    public bool[] goodZone;

    [Header("Liste des boutons par pièce")]
    [SerializeField] private ObjetInteractable boutons;
    [SerializeField] private ObjetInteractable[] boutonsP0;   
    [SerializeField] private ObjetInteractable[] boutonsP1;

    [SerializeField] private ObjetInteractable[] boutonsP2a;
    [SerializeField] private ObjetInteractable[] boutonsP2b;


    [SerializeField] private SoundTrigger[] sound;

    public InputSystemUIInputModule UIInputModule;
    


    // Start is called before the first frame update
    void Awake()
    {   
        m_input = GetComponent<PlayerInput>();
        m_interagirAction = m_input.actions["Interagir"];
        m_InventaireAction = m_input.actions["Inventaire"];
        m_changeView = m_input.actions["ChangeView"];
        

        //m_inputUI = GetComponent<DefaultInputActions>();
        m_submitAction = UIInputModule.actionsAsset.FindAction("Submit");

        cam = Camera.main;
        foreach(SoundTrigger s in sound) { GetComponentInChildren<AudioSource>(); }

        /*for (int i = 0; i < item.Length; i++)
        {
            boxCollider[i] = item[i].parentObject.GetComponent<BoxCollider>();
        }*/


    }


    private void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        
    }




    private void OnEnable()
    {
        m_interagirAction.performed += Interaction;
        m_InventaireAction.performed += AffichageUI;
        m_submitAction.performed += SubmitAction;
        m_changeView.performed += ChangeView;
    }

    private void OnDisable() 
    {
        m_interagirAction.performed -= Interaction;
        m_InventaireAction.performed -= AffichageUI;
        m_submitAction.performed -= SubmitAction;
        m_changeView.performed -= ChangeView;
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

    void AffichageUI(InputAction.CallbackContext callbackContext)
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        //if (EventSystem.current.IsPointerOverGameObject()) return;


    }

    void SubmitAction(InputAction.CallbackContext callbackContext)
    {   
       
        if(goodZone[0] && m_submitAction.triggered)
        {
            Debug.Log("la porte " + item[0].name + " s'ouvre");
            item[0].RemoveUse();

        }
        if (goodZone[1] && m_submitAction.triggered)
        {
            Debug.Log("la porte " + item[1].name + " s'ouvre");
            item[1].RemoveUse();

        }
        if (goodZone[2] && m_submitAction.triggered)
        {
            Debug.Log("la porte " + item[2].name + " s'ouvre");
            item[2].RemoveUse();

        }
        if (goodZone[3] && m_submitAction.triggered)
        {
            Debug.Log("la porte " + item[3].name + " s'ouvre");
            item[3].RemoveUse();

        }


    }

    void ChangeView(InputAction.CallbackContext callbackContext)
    {
        //volume.SetActive(!volume.activeSelf);
        IRcam.SetActive(!IRcam.activeSelf);
        if (cube != null) cube.SetActive(!cube.activeSelf);
        


    }



    void PorteMoyenne()
    {
        if (sound[0].hasBeenListened && sound[1].hasBeenListened)
        {
            Debug.Log("les sons ont été entendus");
            

            if (boutonsP1[0].isOnUse) { Debug.Log("sound01"); sound[0].m_AudioSource.Play(); }
            if (boutonsP1[1].isOnUse) { Debug.Log("sound02"); sound[1].m_AudioSource.Play(); }



            if (boutonsP1[0].isOnUse && boutonsP1[1].isOnUse)
               { ManageMyEvents.NotifyPorteMoyenne(); }

        }
        else Debug.Log("vous devriez écouter autour de vous");

    }


    void PorteDifficileA()
    {



        // première ligne:
        if (!boutonsP2a[0].isOnUse && boutonsP2a[1].isOnUse && !boutonsP2a[2].isOnUse && boutonsP2a[3].isOnUse) porte2A = true;
        // première ligne:
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


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("pink")) goodZone[0] = true;
        if (other.CompareTag("turquoise")) goodZone[1] = true;
        if (other.CompareTag("yellow")) goodZone[2] = true;
        if (other.CompareTag("orange")) goodZone[3] = true;

    }

    private void OnTriggerExit(Collider other)
    {
        goodZone[0] = false;
        goodZone[1] = false;
        goodZone[2] = false;
        goodZone[3] = false;

    }



}
