using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsToActivate : MonoBehaviour
{
    [SerializeField] private AudioSource src;



    private void OnEnable()
    {
        ManageMyEvents.OnReceive += AppuiBouton;
    }

    private void OnDisable()
    {
        ManageMyEvents.OnReceive -= AppuiBouton;
    }

    public void AppuiBouton()
    {   
        

        src.Play();
    }
}
