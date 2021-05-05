using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour

{

    public CharacterController controller;

    public float speed = 12f; // Velocidad de movimiento del personaje (PLAYER)
    public float gravity = -9.81f; // Fuerza de gravedad que se aplica para el personaje (PLAYER)
    public float jumpHeiht = 3f; // Fuerza de salto
    public Transform groundCheck; // Transform de la clase a la cual esté anexada este constructor
    public float groundDistance = 0.4f; //Distancia del suelo mientras se esta en el aire
    public LayerMask groundMask; // mascara (LAYER) del groundmask (Identifica que objetos serán los que se puedan pisar)
    public GameObject luz; // Clase del objeto que contiene a la luz
    public int ContadorEncendidoLuz = 0; // contador para saber si la luz esta encendida o apagada
    bool isGrounded; // Reviza si esta en el suelo, y si es verdadero, entonces la velocidad no se acumulará en Y (Además determina si se puede saltar o no) 
    Vector3 velocity; // Velocidad que se le asigna al movimiento

    // variables de la zona de miedo de los monstruos
    public Camera _camera; // variable de la camara 
    public float _timerFear = 8.0f; // Tiempo maximo que el jugado puede permanecer en la zona de miedo
    public float _timerFearReseter = 8.0f; // Tiempo que se designa para resetear el valor original del timerFear cuando el jugador sale de la zona y el contador todavia no ha llegado a cero
    public bool _OnFear = false; // variable bool que reviza si está o no en la zona de miedo

    // script interaction
    public Interaction _interaction_script;
    // gameobj que contiene el script de interaction 
    public GameObject _interaction_Obj_SpotL;  

    static public float bateria = 25.0f;

    // variables - parametros del patrón observer
    public int contador_Monstruos_Iluminados = 0;
    // int total_Monstruos_Iluminar = 8;

    patron_Observer._Observable _observable = new patron_Observer._Observable();



    public void Victoria()
    {
        
    }


    private void Start()
    {
        _OnFear = false;

        // Instancia los observadores concretos con su respectivas acciones y respuestas al notify()
        patron_Observer._Observer_concreto Concrete_Observer = new patron_Observer._Observer_concreto(this.gameObject, new patron_Observer._Monster_Count());
        // Suscribe los observadores al observable
        _observable.AddObserver(Concrete_Observer);

    }
 




    void Update()
    {

        /* if (_interaction_Obj_SpotL.activeSelf)
        {
            if(_interaction_script.Obj3_Monster_Collider == null)
            {
                _timerFear = _timerFearReseter;
            }
            else _timerFear = _timerFearReseter;
        }
        */


        // Si un monstruo es iluminado entonces: 

        if(_interaction_script._If_Swap_Is_True == true)
        {
            _OnFear = false;
            _interaction_script._If_Swap_Is_True = false;
            _observable.Notify(); // Patrón Observer
            patron_Observer._Observer_concreto.Total_Monstruos_Contados = contador_Monstruos_Iluminados;
            

        }

        if(contador_Monstruos_Iluminados == 8)
        {
            // AQUI OSA SE HACE LA PINCH ANIMACION O LO QUE VAYA A PASAR CUANDO EL JUGADOR TERMINA EL JUEGO 
            // Victoria();
        }


        if (_OnFear == false)
        {
            _timerFear = _timerFearReseter;           
        }



       if (ContadorEncendidoLuz == 1)
       bateria -= Time.deltaTime;

       if (bateria <= 0)
       luz.gameObject.SetActive(false);

       



        // Funcion del Boton de encendido y apagado de la luz

        ButtonLight();


        // crea una esfera en el objeto groundCheck. Esa esfera reviza si esta colisionando con el suelo
        // Si la esfera está colisionando con ALGO en el suelo dentro de la esfera, entonces el bool grounded va a ser verdadero (true)


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); // Movimiento horizontal
        float z = Input.GetAxis("Vertical"); // Movimiento Vertical

        Vector3 move = transform.right * x + transform.forward * z; // Fuerza al movimiento en la dirección de x

        controller.Move(move * speed * Time.deltaTime); // Funcíón que asigna el movimiento de un componente controlador en un objeto

        // Salto

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeiht * -2 * gravity);
        }

        // "Smooth" en la caida
        velocity.y += gravity * Time.deltaTime;
        // "Smooth" en el mov en X
        controller.Move(velocity * Time.deltaTime);
    }


    void ButtonLight()
        // Boton de la luz (Encender - Apagar) 
    {
        if (Input.GetKeyDown(KeyCode.F) && bateria > 0)
            {
            

            if(ContadorEncendidoLuz == 0)
            {
                luz.gameObject.SetActive(true);
                ContadorEncendidoLuz = 1;
            }
            else if (ContadorEncendidoLuz == 1)
            {
                
                luz.gameObject.SetActive(false);
                ContadorEncendidoLuz -= 1;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("colliderMonstruo"))
        {
            _ZonaDeMiedo();
            
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("colliderMonstruo"))
        {
            _timerFear = _timerFearReseter;
           
        }

        _OnFear = false;

    }
   

    public void _ZonaDeMiedo()
    {
        _OnFear = true;

        if (_OnFear == true)
        {
            _timerFear -= Time.deltaTime;

        }

        if (_timerFear <= 0)
        {
           FindObjectOfType<GameManager>().EndGame(); 

        }

    }

    // Patron observer
    /*
    public void Monster_Flag_Contador(int Monstruos_Contados)
    {

        contador_Monstruos_Iluminados += Monstruos_Contados;

    }

    
    private void OnEnable()
    {
        Sujeto_Player.Monster_flagged += Monster_Flag_Contador;
    }

    private void OnDisable()
    {
        Sujeto_Player.Monster_flagged -= Monster_Flag_Contador;
    }
    */

}
