using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// d�sactive les cam�ras et les boutons quand on entre dans une zone d�limit�e par un trigger apr�s chaque porte
/// </summary>

public class CamTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private int camPriority = 10;


    [SerializeField] ObjetInteractable[] bouton;


    private void OnTriggerExit(Collider other)
    {
        if (vCam.Priority > 10)
        {
            vCam.Priority = 0;

            foreach( ObjetInteractable b in bouton)
            {
                b.isOnUse = false;
            }
        }
    }
}
