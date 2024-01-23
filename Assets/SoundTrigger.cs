using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Inspir� du script qui g�re le fire rate de LandOfConfusion
/// attach� � 
/// </summary>
public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_AudioSource;

   


    float fireRate = 5f;
    float nextFire = 0f;



    void Update()
    {
        // toutes les 5 secondes, le son se lance
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            m_AudioSource.Play();

            Debug.Log(Mathf.Round(Time.time));
            Debug.Log(gameObject.name);


        }

    }


}
