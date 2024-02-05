using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Ce script gère le Raycast des objets que l'on peut COLLECTER (Grabbable Object)
/// Il est sur le Player
/// </summary>
public class GrabDropRaycast : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int maxDistance;

    [SerializeField] private Transform grabPointTransform;


    PlayerInput m_input;
    InputAction m_interagirAction;

    RaycastHit hit;



    private void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        m_interagirAction = m_input.actions["Interagir"];
       
    }


    void Update()
    {

        if (m_interagirAction.triggered) 
        {

            RaycastingPickUp();

        }
    }

    void RaycastingGrab()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))

            if (hit.transform.TryGetComponent(out GrabbableObject grabbableObject))
            {
                Debug.Log(grabbableObject);
                grabbableObject.Grab(grabPointTransform);
            }
    }

    void RaycastingPickUp()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))

            if (hit.transform.TryGetComponent(out GrabbableObject grabbableObject))
            {
                Debug.Log(grabbableObject.item.name);
                bool wasPickedUp = Inventaire.instance.Add(grabbableObject.item);

                if(wasPickedUp)
                Destroy(grabbableObject.gameObject);
            }

    }
}
