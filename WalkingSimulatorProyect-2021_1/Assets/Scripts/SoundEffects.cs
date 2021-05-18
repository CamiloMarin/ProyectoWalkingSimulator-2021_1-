using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public AudioSource enemysound;
    // Start is called before the first frame update
   

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {
            enemysound.Play();
        }

    }
}
