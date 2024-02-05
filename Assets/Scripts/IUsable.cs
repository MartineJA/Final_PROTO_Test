using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Interface pour allumer les boutons
/// Object INTERACTABLE
/// </summary>
/// 

public interface IUsable 
{
    public UnityEvent onUse { get;  set; }
    public void Use();
}
