using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private GameObject _assignedPlayer;
    [SerializeField] private Image _healthBar;
    
    private int _playerCurLife;

    private void Start()
    {
        
    }

    private void Update()
    {
        _playerCurLife = _assignedPlayer.GetComponent<KillableObject>().ObjectCurLife;
        UpdateHealthUI();
    }


    private float barCurValue; 
    [SerializeField] private float _updateTime;
    void UpdateHealthUI()
    {
        float pLife = ThomasMathematics.ProduitEnCroix(_assignedPlayer.GetComponent<KillableObject>().ObjectBaseLife, 1, _playerCurLife); 
        float barOldValue = 0;
        float t = _updateTime * Time.deltaTime;
        
        if (barOldValue != pLife)
        {
            barOldValue = pLife;
            barCurValue = Mathf.Lerp(barOldValue, pLife, t) ;
           
        }

        _healthBar.fillAmount = barCurValue;
    }

    
}
