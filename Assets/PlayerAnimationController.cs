using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Animator _playerAnimator;

    [SerializeField] private GameObject _PlayerModel;
    
    private float _playerXVelocity, _playerYVelocity, _playerZVelocity;

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
        _playerXVelocity = Mathf.Clamp(_playerController.curXVel, -1, 1);
        _playerZVelocity = Mathf.Clamp(_playerController.curZVel, -1, 1);
        _playerYVelocity = Mathf.Clamp(_playerController.curYVel, -1, 1);
    }

    private void LinkAnimationToMovement()
    {
        _playerAnimator.SetFloat("VelY", _playerYVelocity);

        if(gameObject.transform.rotation.eulerAngles.y >= 45 && gameObject.transform.rotation.eulerAngles.y <= 130) {_playerAnimator.SetFloat("VelX", _playerXVelocity);}
        else if(gameObject.transform.rotation.eulerAngles.y <= -45 && gameObject.transform.rotation.eulerAngles.y >= -130) {_playerAnimator.SetFloat("VelX", -_playerXVelocity);}
        
    }
}
