using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// attaché à Indice 1221
/// 
/// </summary>
public class SoundTrigger : MonoBehaviour
{
    
    public AudioSource m_AudioSource;

    public bool hasBeenListened;




    private void OnTriggerEnter(Collider other)
    {
        m_AudioSource.Play();
        hasBeenListened = true;
    }






}
