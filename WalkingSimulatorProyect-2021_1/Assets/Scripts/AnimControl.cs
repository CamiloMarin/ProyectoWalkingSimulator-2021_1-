using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
	public GameObject Billy;

    void Update()
    {
        if (Input.GetButton("Walk"))
        {
        	Billy.GetComponent<Animator>().Play ("Walk");
        }
        else
        {
        	Billy.GetComponent<Animator>().Play ("Stay");
        }

    }
}
