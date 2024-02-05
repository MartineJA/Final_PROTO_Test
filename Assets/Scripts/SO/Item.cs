using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// D�finition des objets collectables
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
    

        Debug.Log(name + "  ne peut pas s'utiliser ici");
        
   

    }

   
}
