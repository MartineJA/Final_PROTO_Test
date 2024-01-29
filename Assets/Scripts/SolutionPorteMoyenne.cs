using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SolutionPorteMoyenne : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vCam;


    [SerializeField]
    private int camPriority = 10;

    [SerializeField] AudioSource m_audio;

    private void OnEnable()
    {
        ManageMyEvents.OnPorteMoyenne += OpenMediumDoor;
    }


    private void OnDisable()
    {
        ManageMyEvents.OnPorteMoyenne -= OpenMediumDoor;
    }

    private void OpenMediumDoor()
    {

        transform.position = Vector3.up;

        // créer une animation de porte qui s'ouvre svp
        // avec un son de porte en pierre qui s'ouvre svp


        // changer la couleur de la porte: via ObjetInteractable 



        // créer une particule 



        // jouer un son
        m_audio.Play();



        // interrompre le clic 
        //m_audioToStop.Stop();


        // changer de cam
        vCam.Priority += camPriority;


        Debug.Log("open porte moyenne");



    }
}
