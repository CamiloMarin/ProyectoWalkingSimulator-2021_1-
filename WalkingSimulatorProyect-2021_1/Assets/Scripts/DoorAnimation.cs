using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator door;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        door.SetBool("Open", true);
    }
    else{
        if (Input.GetKeyUp(KeyCode.E))
        {
            door.SetBool("Open", false);
        }
    }

    }
}
