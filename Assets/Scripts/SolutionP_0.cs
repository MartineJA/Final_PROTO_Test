using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionP_0 : MonoBehaviour
{

    [SerializeField] private GameObject door;
    [SerializeField] private AudioSource m_audioToStart;
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


        // changer la couleur de la porte: via ObjetInteractable 



        // créer une particule 



        // jouer un son
        m_audioToStart.Play();



        // interrompre le clic 
        // m_audioToStop.Stop();


        // changer de cam



        Debug.Log("open door");
    }


}
