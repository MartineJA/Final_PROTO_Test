using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receive : MonoBehaviour
{


    
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
        
        Debug.Log(gameObject.name + "          réponse");



    }

}
