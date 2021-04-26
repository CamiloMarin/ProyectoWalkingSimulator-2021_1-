using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour{


	public GameObject OpenPanel = null;
    private bool _isInsideTrigger = false;

	private float bateriaRecargada = 28f;


    private void OnTriggerEnter(Collider other)
    {
    	if (other.tag == "Player")
    	{
    		_isInsideTrigger = true;
            OpenPanel.SetActive(true);
    	}
    }
     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            OpenPanel.SetActive(false);
        }
    }
    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }
     void Update () {

        if(IsOpenPanelActive && _isInsideTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                PlayerScript.bateria += bateriaRecargada;
    			Destroy(gameObject);  
            }
        }
	}

}
