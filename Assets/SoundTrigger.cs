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
    [SerializeField]
    private AudioSource m_AudioSource;






    private void OnTriggerEnter(Collider other)
    {
        m_AudioSource.Play();

    }






}
