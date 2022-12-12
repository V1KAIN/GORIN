using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private GameObject _assignedPlayer;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float updateSpeed;

    private KillableObject _killableObject;

    private void Awake()
    {
        // Get the KillableObject component attached to the player
        _killableObject = _assignedPlayer.GetComponent<KillableObject>();
    }

    private void Update()
    {
        // Calculate the current fill amount of the health bar
        float fillAmount = ThomasMathematics.ProduitEnCroix(_killableObject.ObjectBaseLife,1 , _killableObject.ObjectCurLife) ;

        // Smoothly interpolate the fill amount over time
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, fillAmount, Time.deltaTime * updateSpeed);
    }
}
