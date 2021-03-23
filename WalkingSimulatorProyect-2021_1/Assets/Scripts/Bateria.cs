﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour

{
	private float bateriaRecargada = 28f;


    private void OnTriggerEnter(Collider other)
    {
    	if (other.tag == "Player")
    	{
    		PlayerScript.bateria += bateriaRecargada;
    		Destroy(gameObject);
    	}
    }

}
