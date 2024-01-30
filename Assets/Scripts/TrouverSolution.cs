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
        // changer de cam�ra avec les priorit�s de cam

        // ouvrir la porte
        // revenir � la premi�re cam�ra

    }

}
 