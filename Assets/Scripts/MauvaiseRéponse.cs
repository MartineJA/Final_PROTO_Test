using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauvaiseRéponse : MonoBehaviour
{
    private void OnEnable()
    {
        ManageMyEvents.OnBadAnswer += Bad;
    }

    private void OnDisable()
    {
        ManageMyEvents.OnBadAnswer -= Bad;
    }

    private void Bad()
    {
        Debug.Log("C'est une mauvaise réponse");
    }
}
