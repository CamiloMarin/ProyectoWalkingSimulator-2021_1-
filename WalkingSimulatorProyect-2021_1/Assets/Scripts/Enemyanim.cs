using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyanim : MonoBehaviour
{
    public Animator enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {
            enemy.SetBool("Walk", true);
        }
       
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
