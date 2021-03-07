using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   	static public float bateria = 10f;

    private void Start()
    {
        
    }


    private void FixedUpdate()
    {
        
    }

    void Update()
    {

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

}
