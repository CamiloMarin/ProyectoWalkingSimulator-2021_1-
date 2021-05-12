using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command_Pattern;


    public class _Command_Ejecutor : MonoBehaviour
    {
        // Comandos:

        private _Command _Victoria_Cmd;
        private _Command _Derrota_Cmd;

        // PlayerScript

       
        private PlayerScript playerGameOb;

    void Awake()
        {
            _Victoria_Cmd = new Victoria_Command();
            _Derrota_Cmd = new Derrota_Command();

            playerGameOb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        }

        void Update()
        {
            if(playerGameOb.contador_Monstruos_Iluminados == 8)
            {
                _Victoria_Cmd.Execute(playerGameOb);
                
            }
            if (playerGameOb._timerFear <= 0)
            {
                // Derrota();
                FindObjectOfType<GameManager>().EndGame();
                _Derrota_Cmd.Execute(playerGameOb);

            }
    }

    }


