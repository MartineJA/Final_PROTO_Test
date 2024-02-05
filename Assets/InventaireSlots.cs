using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireSlots : MonoBehaviour
{

    public Image image;
    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;
        image.sprite = item.icon;
        image.enabled = true;
    }


    public void ClearSlot()
    {
        item = null;
        image.sprite = null;
        image.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
