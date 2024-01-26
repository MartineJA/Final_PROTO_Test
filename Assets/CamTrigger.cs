using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;

    [SerializeField] private int camPriority = 10;


    private void OnTriggerEnter(Collider other)
    {
        vCam.Priority += camPriority;
    }
    private void OnTriggerExit(Collider other)
    {
        vCam.Priority -= camPriority;
    }
}
