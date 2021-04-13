using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life_Controller : MonoBehaviour
{
    private Image imageController;
    public float timer_fear_number;
    public float max_timer_fear_number;
    PlayerScript _playerScript;

    public void Start()
    {
        imageController = GetComponent<Image>();
        _playerScript = FindObjectOfType<PlayerScript>();
        timer_fear_number = _playerScript._timerFear;
        max_timer_fear_number = timer_fear_number;
    }

    public void LifeBar()
    {
        if(_playerScript._OnFear == true)
        {
            imageController.enabled = true;
        }

        if (_playerScript._OnFear == false)
        {
            imageController.enabled = false;
        }
    }

    public void Update()
    {
        LifeBar();
        timer_fear_number = _playerScript._timerFear;
        imageController.fillAmount = timer_fear_number / max_timer_fear_number;
    }

}
