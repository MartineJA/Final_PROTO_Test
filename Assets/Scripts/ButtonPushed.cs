using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Quand on appuie sur un bouton, le bouton doit: 
/// - changer de couleur
/// - faire un bruit de "clic"
/// 
/// Update: 
/// Je change la couleur via le script ObjetInteractable
/// Probablement que je pourrai faire de même avec les sons
/// </summary>


public class ButtonPushed : MonoBehaviour
{
    [SerializeField] private AudioSource src;
    
    



    private void OnEnable()
    {
        ManageMyEvents.OnButtonPushed += AppuiBouton;
    }

    private void OnDisable()
    {
        ManageMyEvents.OnButtonPushed -= AppuiBouton;
    }

    void AppuiBouton()
    {
        //UnityEngine.Debug.Log(gameObject.name + " appuie sur un bouton");
        src.Play();

       

    }


}
