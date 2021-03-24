using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life_Controller : MonoBehaviour
{
    public PlayerScript _Player_Script;
    public RawImage Life_bar;
    float tiempo_Fear_Left;
    float timer;
    float localx;
    float localy;
    float localz;
    Vector3 start;
    Vector3 finish;


    void Start()
    {
        Life_bar = GetComponent<RawImage>();
        _Player_Script._timerFear = tiempo_Fear_Left;
        tiempo_Fear_Left = timer;

        localx = gameObject.transform.localScale.x;
        localy = gameObject.transform.localScale.y;
        localz = gameObject.transform.localScale.z;

        start = new Vector3(localx, localy, localz);
        finish = new Vector3(0, localy, localz);
        
      
    }

    
    void Update()
    {
        if(_Player_Script._OnFear == true)
        {
           // timer -= Time.deltaTime;
            Start_Life_Bar_Fear();
        }

   
    }

    public void Start_Life_Bar_Fear()
    {
        gameObject.transform.localScale =  Vector3.Lerp(start,finish, timer/Time.deltaTime );
    }
}
