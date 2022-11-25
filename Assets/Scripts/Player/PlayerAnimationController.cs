using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Animator _playerAnimator;

    private float _playerXVelocity, _playerYVelocity, _playerZVelocity;

    private void Start()
    {
        if (_playerAnimator == null || _playerController == null) Debug.LogWarning("Missing Variable in Animation Controller");
    }

    private void Update()
    {
        if(_playerAnimator == null || _playerController == null) return;
        
        GetCurrentPlayerVelocity();
        LinkAnimationToVelocity();
    }

    private void GetCurrentPlayerVelocity()
    {
        _playerXVelocity = Mathf.Clamp(_playerController.curXVel, -1, 1);
        _playerZVelocity = Mathf.Clamp(_playerController.curZVel, -1, 1);
        _playerYVelocity = Mathf.Clamp(_playerController.curYVel, -1, 1);
    }

    private void LinkAnimationToVelocity()
    {
        //Change Animation angle compared to player object rotation
        if (gameObject.transform.rotation.eulerAngles.y >= 45 && gameObject.transform.rotation.eulerAngles.y <= 135)
        {
            _playerAnimator.SetFloat("VelX", _playerXVelocity);
            _playerAnimator.SetFloat("VelZ", -_playerZVelocity);
            
        }
        else if (gameObject.transform.rotation.eulerAngles.y <= 315 && gameObject.transform.rotation.eulerAngles.y >= 225)
        {
            _playerAnimator.SetFloat("VelX", -_playerXVelocity);
            _playerAnimator.SetFloat("VelZ", _playerZVelocity);
        }
        else if (gameObject.transform.rotation.eulerAngles.y <= 225 && gameObject.transform.rotation.eulerAngles.y >= 135)
        {
            _playerAnimator.SetFloat("VelX", -_playerZVelocity);
            _playerAnimator.SetFloat("VelZ", -_playerXVelocity);
        }
        else
        {
            _playerAnimator.SetFloat("VelX", _playerZVelocity);
            _playerAnimator.SetFloat("VelZ", _playerXVelocity);
        }
    }

    public void PlayFireballCastAnimation() { _playerAnimator.SetTrigger("CastOne"); }

    public void PlayTornadoAnimation() { _playerAnimator.SetTrigger("UltimateCast"); }

    public void DashAnimation() { _playerAnimator.SetTrigger("Dash"); }
    
    public void PlayAttackAnimation() { _playerAnimator.SetTrigger("Attack"); }

    public void PlayReinforceAnimation() { _playerAnimator.SetTrigger("Reinforce");}
    
    public void PlayDeadAnimation(){ _playerAnimator.SetTrigger("Dead"); }
}
