using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Objet que l'on peut collecter
/// Il est sur les objets collectables
/// </summary>
public class GrabbableObject : MonoBehaviour
{

    private Rigidbody rgB;
    private Transform grabPointTransform;
    private float lerpSpeed = 100f;


    public Item item;

    private void Awake()
    {
        rgB = GetComponent<Rigidbody>();
    }
    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        rgB.useGravity = false;
    }




    private void FixedUpdate()
    {
        if(grabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
            rgB.MovePosition(newPosition);
        }
    }
}
