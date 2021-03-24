using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Audio : MonoBehaviour
{
    public static Script_Audio _script_audio;
    AudioSource _audioSource; 

    
     void Awake()
    {
        if (Script_Audio._script_audio = null)
        {
            // Se instancia por primera vez  (instancia única) (SINGLETON) 

            Script_Audio._script_audio = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();

        }
        else
        {
            // si ya hay una instancia, entonces que destruya esta.

            Destroy(gameObject);
        }
    }

}
