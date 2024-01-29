using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    [SerializeField] Transform[] raycastOrigin;
    [SerializeField] private float m_raycastLength = 1.5f;
    [SerializeField] private LayerMask m_groundMask;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach(Transform t in raycastOrigin) 
        {
            Gizmos.DrawRay(t.position, Vector3.down * m_raycastLength);
        }
    }


    public Vector3 AverageHeight()
    {
        int m_hitCount = 0;
        Vector3 m_combinedPosition = Vector3.zero;


        RaycastHit hit;

        foreach(Transform t in raycastOrigin)
        {

            if (Physics.Raycast(t.position, Vector3.down, out hit, m_raycastLength, m_groundMask))
            {
                m_hitCount++;
                m_combinedPosition += hit.point; // position dans le monde où le raycast a touché le collider
            }
        }

        Vector3 m_averagePosition = Vector3.zero;

        if(m_hitCount > 0)
        {
            m_averagePosition = m_combinedPosition / m_hitCount;
        }

        return m_averagePosition;
    }

}
