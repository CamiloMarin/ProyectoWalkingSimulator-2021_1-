using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject playerCamera; // GameObj del objeto donde está la camara (DENTRO DEL PLAYER)
    RaycastHit hit; // La variable que almacena el objeto al cual se le aplica el raycast

    public GameObject Obj_0_Parent;
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3_Monster_Collider;
    public Vector3 tempPosition;
    public bool _If_Swap_Is_True = false;

       // variables que sirven para cambiar los objetos una vez

    private int score = 1;
    private int oldScore = 2;

    void Start()
    {

       

    }

    public void Swap()
    {
        /* tempPosition = Obj1.transform.localPosition;
        Obj1.transform.localPosition = Obj2.transform.localPosition;
        Obj2.transform.localPosition = tempPosition; */

        tempPosition = new Vector3(Obj1.transform.position.x, Obj2.transform.position.y, Obj1.transform.position.z);
        Obj1.transform.position = new Vector3(Obj2.transform.position.x, Obj1.transform.position.y, Obj2.transform.position.z);
        Obj2.transform.position = tempPosition;
        _If_Swap_Is_True = true;

    }



    // Update is called once per frame
    void Update()
    {

        // RAYCAST 

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * 8.0f, Color.red);
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, 3.0f))
        {
           // hit.transform.gameObject.transform.position = new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));

            if (Obj1 == null && Obj_0_Parent == null && Obj2 == null && Obj3_Monster_Collider == null)
            {
                if (hit.collider.tag.Equals("cambiante") && score != oldScore)

                {
                    
                    Obj1 = hit.collider.gameObject; // Captura el objeto que es señalado con el raycast (siempre y cuando este tenga el tag con el nombre "cambiante"
                    Obj_0_Parent = Obj1.transform.parent.gameObject; // captura el objeto 'padre' del objeto "Obj1"
                    Obj2 = Obj_0_Parent.transform.GetChild(1).gameObject; // captura el objeto de la jerarquia #1 del objeto padre.
                    Obj3_Monster_Collider = Obj_0_Parent.transform.GetChild(2).gameObject;  // captura el tercer el objeto de la jerarquia del objeto padre

                    Swap();

                   

                    Obj1.gameObject.layer = 2; // se coloca el objeto que se obtiene del raycast en una capa que ignore el raycast para que no vuelva a cambiar.
                    Obj2.gameObject.layer = 2;
                    // Destroy(Obj3_Monster_Collider.gameObject);
                    Obj3_Monster_Collider.SetActive(false);
                   
                    score = oldScore;

                    Obj1 = null;
                    Obj_0_Parent = null;
                    Obj2 = null;
                    Obj3_Monster_Collider = null;
                    score -= 1;
                  

                }

                


            }



        }
           
            



            
        
    }
}
