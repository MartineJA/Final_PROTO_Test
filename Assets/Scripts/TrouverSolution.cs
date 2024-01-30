using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class TrouverSolution : MonoBehaviour
{
    //public GameObject[] boutonsActivables;

    [SerializeField]
    private CinemachineVirtualCamera vCam;


    [SerializeField]
    private int camPriority = 10;


    private void OnEnable()
    {
        ManageMyEvents.OnSolutionFound += BonneCombinaison;
    }


    private void OnDisable()
    {
        ManageMyEvents.OnSolutionFound += BonneCombinaison;
    }

    void BonneCombinaison()
    {

        transform.position = Vector3.up;
        vCam.Priority += camPriority;

        // jouer un son
        // changer de caméra avec les priorités de cam

        // ouvrir la porte
        // revenir à la première caméra

    }

}
 