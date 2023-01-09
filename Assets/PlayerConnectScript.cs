using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConnectScript : MonoBehaviour
{
    [SerializeField] private PlayersManager _playersManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerAttackManager _playerAttackManager;
    [SerializeField] private PlayerUIScript _playerRelatedUI;

    private void Start()
    {
        _playersManager = GameObject.FindWithTag("MultiplayerManager").GetComponent<PlayersManager>();
        _playersManager.ConnectPlayer(gameObject);
        FreezePlayer();
    }

    //Enables and assign the player scripts 
    public void PlayerStartPlay()
    {
        _playerController.enabled = true;
        _playerController.AssignVariables();
        //
        _playerAttackManager.enabled = true;
        _playerAttackManager.AssignVariables();
        //
        _playerRelatedUI.enabled = true;
        _playerRelatedUI.AssignVariables();
    }

    void FreezePlayer()
    {
        _playerController.enabled = false;
        _playerAttackManager.enabled = false;
        _playerRelatedUI.enabled = false;
    }
}
