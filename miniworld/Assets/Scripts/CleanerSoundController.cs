using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CleanerSoundController : MonoBehaviour
{
    private bool isTrigger = false;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!isTrigger)
            {
                audio.Play();
                isTrigger = true;
            }

            else
                audio.Stop();
        }
    }
}
