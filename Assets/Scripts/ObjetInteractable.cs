using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Ce script est attaché aux GO interactables, et permet d'activer ou de désactiver les propriétés du GO concerné.
/// Il sera utilisé pour allumer et éteindre les boutons des énigmes
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
