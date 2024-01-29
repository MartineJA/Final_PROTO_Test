using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
using System.Linq;

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

    

    

    [Header("Liste des boutons par pièce")]
    [SerializeField] private ObjetInteractable boutons;
    [SerializeField] private ObjetInteractable[] boutonsP0;   
    [SerializeField] private ObjetInteractable[] boutonsP1;

    // [SerializeField] private ObjetInteractable[] boutonsP2;





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
        if (boutons.isOnUse) { ManageMyEvents.NotifyTutoDoor(); } 

        // porte facile
        if (!boutonsP0[0].isOnUse && boutonsP0[1].isOnUse && boutonsP0[2].isOnUse && !boutonsP0[3].isOnUse) { ManageMyEvents.NotifyPorteFacile(); }

        // porte moyenne
        //if (boutonsP1[0].isOnUse && !boutonsP1[1].isOnUse && boutonsP1[2].isOnUse && !boutonsP1[3].isOnUse) { ManageMyEvents.NotifyPorteMoyenne(); }
        PorteMoyenne();
        
       


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
        boutonsP1[0].iD = 0;
        boutonsP1[1].iD = 1;
        boutonsP1[2].iD = 2;
        boutonsP1[3].iD = 3;


        List<int> array = new List<int>() { -1, -1, -1 };




        int[] solution = new int[] { boutonsP1[2].iD, boutonsP1[0].iD};

        



        foreach (ObjetInteractable o in boutonsP1)

        {
            if (o.isOnUse)
            {

                array.Remove(0);
                Debug.Log(o.iD);
                array.Add(o.iD);

                array[0] = array[1];
                array[1] = array[2];
                array[3] = array[3];
                array[3] = o.iD;

                Debug.Log(array.ElementAt(0));
                Debug.Log(array.ElementAt(1));
                Debug.Log(array.ElementAt(2));
                Debug.Log(array.ElementAt(3));



                Debug.Log("array count    " + array.Count);
                

            }

        }




    }



}
