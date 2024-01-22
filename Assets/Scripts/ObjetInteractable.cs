using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Ce script est attach� aux GO interactables, et permet d'activer ou de d�sactiver les propri�t�s du GO concern�.
/// Il sera utilis� pour allumer et �teindre les boutons des �nigmes
/// </summary>
public class ObjetInteractable : MonoBehaviour, IUsable
{
    [SerializeField]
    private UnityEvent _onUse;

    [SerializeField]
    private UnityEvent _offUse;

    public bool isOnUse;

    UnityEvent IUsable.onUse { 
        get => _onUse; 
        set => _onUse = value; }

    public void Use()
    {
        if(isOnUse)
        {
            _offUse.Invoke();
        }
        else
        {
            _onUse.Invoke();
        }

        isOnUse = !isOnUse;

    } 


}
