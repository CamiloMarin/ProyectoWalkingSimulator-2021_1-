using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator door;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

        door.SetBool("Open", true);
    }
    else{
        if (Input.GetKeyUp(KeyCode.X))
        {
            door.SetBool("Open", false);
        }
    }

    }
}
