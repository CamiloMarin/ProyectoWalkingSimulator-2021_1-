using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator door;
    public AudioSource doorSound; 

   void Start (){
       door = GetComponent<Animator>();
   }
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")    
        
        {
            door.SetBool("Open", true);
            doorSound.Play();
        }
        else 
        {
            if (other.tag != "Player" )
            {
                door.SetBool("Open", false);
            }
        }

    }
    
}


