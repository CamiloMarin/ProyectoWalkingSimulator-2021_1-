using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace patron_Observer
{
    public class _Observable
    {
        List<_Observer> observers = new List<_Observer>();

        public void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                // Recorre los observers para notificarlos
                observers[i].OnNotify();
            }

        }


        // Suscripción
        public void AddObserver(_Observer observer)
        {
            observers.Add(observer);
        }

        // Desuscripción
        public void RemoveObserver(_Observer observer)
        {

        }

    }

}

