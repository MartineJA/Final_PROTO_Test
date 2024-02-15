using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Equipement", menuName = "Equipement")]
public class Equipement : Item
{
    public KeySlot key;

    public override void Use()
    {
        base.Use();
        // placer l'item au bon endroit
         




        EquipementManager.instance.Equiper(this);



        // retirer de l'inventaire
        RemoveUse();
    }

    


}

public enum KeySlot { Pink, Orange, Turquoise, Yellow}