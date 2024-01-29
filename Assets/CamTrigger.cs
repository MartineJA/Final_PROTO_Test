using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// désactive les caméras et les boutons quand on entre dans une zone délimitée par un trigger après chaque porte
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
