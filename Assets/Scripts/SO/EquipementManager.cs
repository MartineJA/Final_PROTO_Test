using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementManager : MonoBehaviour
{
    public static EquipementManager instance;
    Inventaire inventaire;
    private void Awake()
    {
        instance = this;
    }

    Equipement[] currentEquipement;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(KeySlot)).Length;
        currentEquipement = new Equipement[numSlots];
    }

    public void Equiper(Equipement newItem)
    {
        int slotIndex = (int)newItem.key;

        Equipement oldItem = Unequip(slotIndex);

        currentEquipement[slotIndex] = newItem;

    }

    public Equipement Unequip(int slotIndex)
    {
        Equipement oldItem = null;
        // Only do this if an item is there
        if (currentEquipement[slotIndex] != null)
        {
            // Add the item to the inventory
            oldItem = currentEquipement[slotIndex];
            inventaire.Add(oldItem);

        }
        return oldItem;
    }

}