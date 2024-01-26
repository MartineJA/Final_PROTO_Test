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

    // Start is called before the first frame update
    void Start()
    {
        m_Started = true;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.OverlapBox(transform.position, m_boxDimension, Quaternion.identity, m_groundMask);

        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
