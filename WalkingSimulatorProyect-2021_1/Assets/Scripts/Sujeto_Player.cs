using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    public class Sujeto_Player : MonoBehaviour
    {
        // Evento cuando se ilumina un monstruo
        public static event Action<int> Monster_flagged;
        public Interaction _interaction_script;


        // Monstruo iluminado

        public void Monster_Illuminated()
        {
            if (Monster_flagged != null)
            {
                Monster_flagged(1);
            }
        }
        
        public void SiHayUnaInteraccion()
        {
            
            if (_interaction_script._If_Swap_Is_True == true)
            {
                Monster_Illuminated();
            }
           
        }

    public void Update()
    {
        SiHayUnaInteraccion();
    }

}


