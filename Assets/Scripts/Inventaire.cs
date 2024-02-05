using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Création de l'inventaire, source: 
/// https://youtu.be/HQNl3Ff2Lpo?si=jEBmRP4_hCL5Lyst
/// </summary>
public class Inventaire : MonoBehaviour
{
    public static Inventaire instance;


    #region singleton
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("plusieurs inventaires attention ");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<Item> items = new List<Item>();
    public int limitSpace = 6; 

    public bool Add(Item item)
    {

        if (items.Count >= limitSpace)
        {

            Debug.Log("plus de place dans l'inventaire, vous devriez trouver comment ulitiser les objets déjà en votre possession");
            return false;
        }

        else
        {
            items.Add(item);
            onItemChangedCallback?.Invoke();

        }

        return true;

    }

    public void Remove (Item item)

    {
        items.Remove(item);
        onItemChangedCallback?.Invoke();
    }


}
