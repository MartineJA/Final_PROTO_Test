using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool m_Started;

    [SerializeField]
    private LayerMask m_groundMask;

    [SerializeField]
    private Vector3 m_boxDimension;


    // Update is called once per frame
    void Update()
    {
       Collider[] groundCollider =  Physics.OverlapBox(transform.position, m_boxDimension, Quaternion.identity, m_groundMask);       

        if(groundCollider.Length > 0) { /*Debug.Log("je touche le sol");*/ }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
       
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, m_boxDimension*2f);
    }
}
