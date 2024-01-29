using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SolutionP_0 : MonoBehaviour
{

    [SerializeField] private GameObject door;

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    

    [SerializeField]
    private int camPriority = 10;
    //[SerializeField] private AudioSource m_audioToStart;
    //[SerializeField] private AudioSource m_audioToStop;
    //[SerializeField] private float speed = 0.5f;

 

    private void OnEnable()
    {
        ManageMyEvents.OnTutoDoor += OpenDoor;
    }


    private void OnDisable()
    {
        ManageMyEvents.OnTutoDoor -= OpenDoor;
    }

    private void OpenDoor()
    {

        door.transform.position = Vector3.up;
        // créer une animation de porte qui s'ouvre svp
        // avec un son de porte en pierre qui s'ouvre svp

        // créer une particule 

        // jouer un son
        //m_audioToStart.Play();

        // interrompre le clic 
        // m_audioToStop.Stop();

        // changer de cam
        vCam.Priority += camPriority;
        
        
        Debug.Log("bordel");

    }




}
