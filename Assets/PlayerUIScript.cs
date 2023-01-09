using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUIScript : MonoBehaviour
{
    [SerializeField] private GameObject _assignedPlayer;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float updateSpeed;

    private KillableObject _killableObject;

    private void Start()
    {
        AssignVariables();
    }

    private void Update()
    {
        // Calculate the current fill amount of the health bar
        float fillAmount = ThomasMathematics.ProduitEnCroix(_killableObject.ObjectBaseLife,1 , _killableObject.ObjectCurLife) ;

        // Smoothly interpolate the fill amount over time
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, fillAmount, Time.deltaTime * updateSpeed);
    }


    void CheckCoolDowns(int skillID)
    {
        
    }

    public void AssignVariables()
    {
        _killableObject = _assignedPlayer.GetComponent<KillableObject>();
    }

    public void AssignUIToPlayer(GameObject player)
    {
        _assignedPlayer = player;
    }
}
