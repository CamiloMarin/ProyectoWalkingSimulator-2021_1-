using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
   
    public void Playgame()
    {
        SceneManager.LoadScene("L1");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HowtoPlay()
    {
        SceneManager.LoadScene("How to play");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
