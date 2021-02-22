using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject playerCamera; // GameObj del objeto donde está la camara (DENTRO DEL PLAYER)
    RaycastHit hit; // La variable que almacena el objeto al cual se le aplica el raycast

    public GameObject Obj1;
    public GameObject Obj2;
    private int score = 1;
    private int oldScore = 2;
    public Vector3 tempPosition;



    void Start()
    {


    }

    public void Swap()
    {
        tempPosition = Obj1.transform.position;
        Obj1.transform.position = Obj2.transform.position;
        Obj2.transform.position = tempPosition;
    }



    // Update is called once per frame
    void Update()
    {

        // RAYCAST 

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward) * 8.0f, Color.red);
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, 3.0f))
        {
            // hit.transform.gameObject.transform.position = new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));
        
            
                if (hit.collider.tag.Equals("cambiante") && score != oldScore)

                {         
          
                    Swap();
                    score = oldScore;
                    


                }  else if (!hit.collider.tag.Equals("cambiante") && score == oldScore)


                {
                     score = 1;
                }

                  
         




        }
           
            



            
        
    }
}
