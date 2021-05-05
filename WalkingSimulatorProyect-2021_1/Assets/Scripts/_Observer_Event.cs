using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace patron_Observer
{
    public abstract class _Observer_Event 
    {
        public abstract float MonstruosContados(); 
 
    }

    public class _Monster_Count : _Observer_Event
    {
        public override float MonstruosContados()
        {
            return 1.0f;
        }
    }
}

