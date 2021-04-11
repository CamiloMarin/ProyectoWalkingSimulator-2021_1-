using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator door;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

        door.SetBool("Open", true);
    }
    else{
        if (Input.GetKeyUp(KeyCode.C))
        {
            door.SetBool("Open", false);
        }
    }

    }
}

