using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrouverSolution : MonoBehaviour
{
    //public GameObject[] boutonsActivables;


    

    private void OnEnable()
    {
        ManageMyEvents.OnSolutionFound += BonneCombinaison;
    }


    private void OnDisable()
    {
        ManageMyEvents.OnSolutionFound += BonneCombinaison;
    }

    void BonneCombinaison()
    {          
            Debug.Log("C'est la bonne combinaison");
           
            
            // jouer un son
            // changer de caméra avec les priorités de cam
            
            // ouvrir la porte
            // revenir à la première caméra
            
    }

}
 