using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]float _walkingSpeed = 3.5f;
    [SerializeField]float _gravity = 20.0f;
    [Space]
    [SerializeField]float _dashSpeed = 8f;
    [SerializeField]float _dashTime = 3f;
    [SerializeField]float _dashCooldown = 5f;

    [Header("Drag & Drop")] 
    [SerializeField] private Animator _playerAnimator;

    //[Header("Stats")] 
    //[SyncVar]public int PlayerHealth = 200;
    

    //Privates
    float _curSpeed;
    CharacterController _characterController;
    Vector3 _pInputs = Vector3.zero;
    Vector3 _moveDir = Vector3.zero;
    private bool _canDash = true;
    private bool _isDashing = false;
        
    //Hidden
    [HideInInspector] public bool CanMove = true;

    public float curXVel, curZVel;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _curSpeed = _walkingSpeed;
    }

    void Update()
    {
        //if (!isLocalPlayer) return;
        
        GetPlayerInputs();
        LookAtMousePosition();

        curXVel = _characterController.velocity.x;
        curZVel = _characterController.velocity.z;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (CanMove)
        {
            _moveDir = (Vector3.right * _pInputs.x) + (Vector3.forward * _pInputs.z);    
        }
        
        if (!_characterController.isGrounded)
        {
            _moveDir.y -= _gravity;
        }

        _curSpeed = _isDashing ? _dashSpeed : _walkingSpeed;
            
        _characterController.Move(_moveDir);
    }
    
    void GetPlayerInputs()
    {
        _pInputs.x = (_curSpeed / 100 ) * Input.GetAxisRaw("Horizontal");
        _pInputs.z = (_curSpeed / 100 ) * Input.GetAxisRaw("Vertical");

        if (_canDash && Input.GetButtonDown("Jump")) StartCoroutine(nameof(Dash));
        else if (Input.GetButtonDown("Jump") && !_canDash) Debug.Log("Dash not available");
    }

    Vector3 mousePos = Vector3.zero;
    void LookAtMousePosition()
    {
        Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosRay, out RaycastHit hit))
        {
            mousePos = new Vector3(hit.point.x, transform.localPosition.y, hit.point.z);
        }
        
        transform.LookAt(mousePos);
    }

    IEnumerator Dash()
    {
        Debug.Log("Dashing");
        _playerAnimator.SetBool("IsInDash", true);
        _isDashing = true;
        _curSpeed = _dashSpeed;
        yield return new WaitForSeconds(_dashTime);
        _isDashing = false;
        _curSpeed = _walkingSpeed;
        StartCoroutine(nameof(DashRecharge));
        _playerAnimator.SetBool("IsInDash", false);
        Debug.Log("stop Dashing");
    }

    IEnumerator DashRecharge()
    {
        Debug.Log("Dash recharging");
        _canDash = false;
        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
        Debug.Log("dash available");
    }

    //[ClientRpc]
    void AnimateCharacter()
    {
        //Link Animation
    }
}
