using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Définition des objets collectables
/// </summary>

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject 
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string description;

    public GameObject parentObject;

    

    public virtual void Use()
    {  
        Debug.Log("using " + name);       
    }

   public virtual void RemoveUse()
    {
        Inventaire.instance.Remove(this);
    }
}
