using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionP_1 : MonoBehaviour
{

    [SerializeField] private GameObject door;
    //[SerializeField] private float speed = 0.5f;

    private void OnEnable()
    {
        ManageMyEvents.OnSolutionFound += OpenDoor;
    }


    private void OnDisable()
    {
        ManageMyEvents.OnSolutionFound -= OpenDoor;
    }

    private void OpenDoor()
    {

        door.transform.position = Vector3.up;
        Debug.Log("open door");
    }


}
