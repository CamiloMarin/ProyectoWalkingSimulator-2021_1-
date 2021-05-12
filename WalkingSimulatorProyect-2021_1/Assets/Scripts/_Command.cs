using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command_Pattern
{
    public interface _Command 
    {
        // Clase Abstracta de Command 
        void Execute(PlayerScript playerGameOb);
      
    }

    public class Victoria_Command : _Command
    {
        public void Execute(PlayerScript playerGameOb)
        {
            playerGameOb.Victoria();
        }
    }
    
    public class Derrota_Command : _Command
    {
        public void Execute(PlayerScript playerGameOb)
        {
            playerGameOb.Derrota();
        }
    }

  
}

