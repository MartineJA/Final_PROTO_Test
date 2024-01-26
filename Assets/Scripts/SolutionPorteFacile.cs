using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SolutionPorteFacile : MonoBehaviour
{

    //[SerializeField] private GameObject door;
    //[SerializeField] private AudioSource m_audioToStart;
    //[SerializeField] private AudioSource m_audioToStop;
    //[SerializeField] private float speed = 0.5f;

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private int camPriority = 10;

    private void OnEnable()
    {
        ManageMyEvents.OnPorteFacile += OpenDoor;
    }


    private void OnDisable()
    {
        ManageMyEvents.OnPorteFacile -= OpenDoor;
    }

    private void OpenDoor()
    {

        transform.position = Vector3.up;

        // créer une animation de porte qui s'ouvre svp
        // avec un son de porte en pierre qui s'ouvre svp


        // changer la couleur de la porte: via ObjetInteractable 



        // créer une particule 



        // jouer un son
        //m_audioToStart.Play();



        // interrompre le clic 
        //m_audioToStop.Stop();


        // changer de cam
        vCam.Priority += camPriority;


        Debug.Log("open porte facile");
    }


}
