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
            // changer de cam�ra avec les priorit�s de cam
            
            // ouvrir la porte
            // revenir � la premi�re cam�ra
            
    }

}
 