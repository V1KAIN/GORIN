using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConnectScript : MonoBehaviour
{
    [SerializeField] private PlayersManager _playersManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerAttackManager _playerAttackManager;

    private void Start()
    {
        _playersManager.ConnectPlayer(gameObject);
        FreezePlayer();
    }

    public void PlayerStartPlay()
    {
        _playerController.enabled = true;
        _playerAttackManager.enabled = true;
    }

    void FreezePlayer()
    {
        _playerController.enabled = false;
        _playerAttackManager.enabled = false;
    }
}
