using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Animator _playerAnimator;

    [SerializeField] private GameObject _PlayerModel;
    
    private float PlayerZVelocity;
    private float PlayerXVelocity;

    private void Start()
    {
        if (_playerAnimator == null || _playerController == null) Debug.LogWarning("Missing Variable in Animation Controller");
    }

    private void Update()
    {
        if(_playerAnimator == null || _playerController == null) return;
        
        GetCurrentPlayerVelocity();
        LinkAnimationToMovement();
    }

    private void GetCurrentPlayerVelocity()
    {
        PlayerXVelocity = _playerController.curXVel;
        PlayerZVelocity = _playerController.curZVel;
    }

    private void LinkAnimationToMovement()
    {
        _playerAnimator.SetFloat("VelY", PlayerXVelocity);
        _playerAnimator.SetFloat("VelX", PlayerZVelocity);
    }
}
