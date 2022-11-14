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

    [Header("Player Settings")] 
    [SerializeField] private float _playerLookAtSpeed = .2f;
    [Space]

    //Privates
    float _curSpeed;
    CharacterController _characterController;
    Vector3 _pInputs = Vector3.zero;
    Vector3 _moveDir = Vector3.zero;
    private bool _canDash = true;
    private bool _isDashing = false;
        
    //Hidden
    [HideInInspector] public bool CanMove = true;

    [Header("DEBUG")]
    public float curXVel;
    public float curZVel; 
    public float curYVel;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _curSpeed = _walkingSpeed;
    }

    void Update()
    {
        GetPlayerInputs();
        LookAtMousePosition();

        curXVel = _characterController.velocity.x;
        curZVel = _characterController.velocity.z;
        curYVel = _characterController.velocity.y;
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
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            if (_pInputs.x > 0.01f &&  _pInputs.z > 0.01f)
            {
                _pInputs.x = (_curSpeed / 100 ) * Input.GetAxis("Horizontal") /1.8f;
                _pInputs.z = (_curSpeed / 100 ) * Input.GetAxis("Vertical") /1.8f ;
            }
            if (_pInputs.x < 0.01f &&  _pInputs.z < 0.01f)
            {
                _pInputs.x = (_curSpeed / 100 ) * Input.GetAxis("Horizontal") /1.8f;
                _pInputs.z = (_curSpeed / 100 ) * Input.GetAxis("Vertical") /1.8f ;
            }
            if (_pInputs.x > 0.01f &&  _pInputs.z < 0.01f)
            {
                _pInputs.x = (_curSpeed / 100 ) * Input.GetAxis("Horizontal") /1.8f;
                _pInputs.z = (_curSpeed / 100 ) * Input.GetAxis("Vertical") /1.8f ;
            }
            if (_pInputs.x < 0.01f &&  _pInputs.z > 0.01f)
            {
                _pInputs.x = (_curSpeed / 100 ) * Input.GetAxis("Horizontal") /1.8f;
                _pInputs.z = (_curSpeed / 100 ) * Input.GetAxis("Vertical") /1.8f ;
            }
        }
        else
        {
            _pInputs.x = (_curSpeed / 100 ) * Input.GetAxis("Horizontal");
            _pInputs.z = (_curSpeed / 100 ) * Input.GetAxis("Vertical");
        }

        //if (_canDash && Input.GetButtonDown("Jump")) StartCoroutine(nameof(Dash));
        //else if (Input.GetButtonDown("Jump") && !_canDash) Debug.Log("Dash not available");
    }

    Vector3 mousePos = Vector3.zero;
    private Quaternion _rotGoal;
    private Vector3 _lookAtDir;
    void LookAtMousePosition()
    {
        Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosRay, out RaycastHit hit))
        {
            mousePos = new Vector3(hit.point.x, transform.localPosition.y, hit.point.z);
        }

        _lookAtDir = (mousePos - transform.position).normalized;
        _rotGoal = Quaternion.LookRotation(_lookAtDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotGoal, _playerLookAtSpeed);
    }
    
}
