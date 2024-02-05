using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventaireUI : MonoBehaviour
{
    public Transform itemsParents;
  




    Inventaire inventaire;

    InventaireSlots[] slots;




    void Start()
    {
        inventaire = Inventaire.instance;
        inventaire.onItemChangedCallback += UpdateUI;

        slots = itemsParents.GetComponentsInChildren<InventaireSlots>();
    }






    // Update is called once per frame
    void UpdateUI()
    {
        Debug.Log("UpdateUI");
        for(int i = 0; i<slots.Length; i++)
        {
            if(i<inventaire.items.Count)
            {
                slots[i].AddItem(inventaire.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }
}
