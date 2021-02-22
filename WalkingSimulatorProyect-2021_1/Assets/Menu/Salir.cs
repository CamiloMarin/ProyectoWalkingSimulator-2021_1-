using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Salir : MonoBehaviour
{
    public GameObject interface2;
    public Button salir;
    // Start is called before the first frame update
   public void Exit()
    {
        interface2.SetActive(false);
    }
}
