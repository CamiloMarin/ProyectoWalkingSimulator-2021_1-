using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace patron_Observer
{
    public abstract class _Observer : MonoBehaviour
    {
        public abstract void OnNotify();
    }

    public class _Observer_concreto : _Observer
    {
        public static float Total_Monstruos_Contados_Checkeados;
        public static float Monstruo_Checkeado = 1.0f;


        // Este es el clase-objeto que va a reaccionar al notify

        GameObject Concrete_Observer;
       

        // Evento de la clase Car_PowerUp_Event que define la funcion abstracta a ejecturar en el notify

        _Observer_Event Contando_Monstruos;

        public _Observer_concreto(GameObject Concrete_Observer, _Observer_Event Contando_Monstruos)
        {
            this.Concrete_Observer = Concrete_Observer;
            this.Contando_Monstruos = Contando_Monstruos;
        }

        void Notify_Monstruos_Contados(float Monstruos_Contados)
        {
            if(Monstruo_Checkeado == Monstruos_Contados)
            {
                Total_Monstruos_Contados_Checkeados += 1.0f;
            }
            
           
           

        }

        public override void OnNotify()
        {
            // cuando se notifique que haga algo 
            Notify_Monstruos_Contados(Contando_Monstruos.MonstruosContados());

        }

    }

}


