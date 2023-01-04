using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]float _walkingSpeed = 3.5f;
    [SerializeField]float _gravity = 20.0f;
    [Space]
    [SerializeField]float _dashSpeed = 3f;
    [SerializeField]float _dashTime = 0.3f;
    [SerializeField]float _dashCooldown = 4f;
    
    [Header("Settings")] 
    [SerializeField] private float _playerLookAtSpeed = .2f;
    [SerializeField] private PlayerAnimationController _playerModelAnimator;
    [SerializeField] private MeshTrailScript _meshTrail;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _movementRelativeToRot;
    [SerializeField] private bool _dashForward;
    
    [Space]
    //Privates
    float _curSpeed;
    CharacterController _characterController;
    PlayerAttackManager _attackController;
    Vector3 _pInputs = Vector3.zero;
    Vector3 _moveDir = Vector3.zero;
    private bool _canDash = true;
    private bool _isDashing = false;
    private bool _lookAtMousePos = true;
        
    //Hidden
    [HideInInspector] public bool CanMove = true;

    [Header("DEBUG")]
    public float curXVel;
    public float curZVel; 
    public float curYVel;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _attackController = GetComponent<PlayerAttackManager>();
        _playerModelAnimator = GetComponent<PlayerAnimationController>();
        _meshTrail = GetComponent<MeshTrailScript>();
    }

    void Update()
    {
        GetPlayerInputs();
        LookAtMousePosition();
        
        _curSpeed = _walkingSpeed;
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
            if(!_movementRelativeToRot){_moveDir = (Vector3.right * _pInputs.x) + (Vector3.forward * _pInputs.z);}
            else
            {
                _moveDir = (transform.right * _pInputs.normalized.x) + (transform.forward * _pInputs.normalized.z);
            }
        }
        
        if (!_characterController.isGrounded)
        {
            _moveDir.y -= _gravity;
        }

        if (!_isDashing)
        {
            _characterController.Move(_moveDir);
        }
    }

    public void OnMove(InputValue value)
    {
        _pInputs.x = value.Get<Vector2>().x * _curSpeed;
        _pInputs.z = value.Get<Vector2>().y * _curSpeed;
    }

    public void OnDash()
    {
        if (_canDash && !_isDashing)
        {
            StartCoroutine(nameof(Dash));
            transform.rotation = _rotGoal;
            if (_dashForward)
            {
                _dashDir = transform.forward;
            }
            else
            {
                _dashDir = _moveDir * 10;
            }
            _canDash = false;
        }
    }

    void GetPlayerInputs()
    {
        
        
       //_pInputs.x = (_curSpeed ) * Input.GetAxis("Horizontal");
       // _pInputs.z = (_curSpeed ) * Input.GetAxis("Vertical");


        /*if (Input.GetButtonDown("Jump") && _canDash && !_isDashing)
        {
            StartCoroutine(nameof(Dash));
            transform.rotation = _rotGoal;
            if (_dashForward)
            {
                _dashDir = transform.forward;
            }
            else
            {
                _dashDir = _moveDir * 10;
            }
            _canDash = false;
        }*/
    }
    
    

    Vector3 mousePos = Vector3.zero;
    private Quaternion _rotGoal;
    private Vector3 _lookAtDir;
    void LookAtMousePosition()
    {
        /*
        Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosRay, out RaycastHit hit, float.MaxValue, _groundLayer))
        {
            mousePos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        
        _lookAtDir = (mousePos - transform.position).normalized;
        _rotGoal = Quaternion.LookRotation(_lookAtDir); _rotGoal.x = 0; _rotGoal.z = 0;
        if(_lookAtMousePos)transform.rotation = Quaternion.Slerp(transform.rotation, _rotGoal, _playerLookAtSpeed);
        */
    }

    private Vector3 _dashDir = new Vector3();
    IEnumerator Dash()
    {
        _isDashing = true;
        _canDash = false;
        _lookAtMousePos = false;
        _meshTrail.StartTrail();
        float startTime = Time.time;
        _playerModelAnimator.DashAnimation();

        while (Time.time < startTime + _dashTime)
        {
            Debug.Log("CurrentlyDashing");
            _characterController.Move(_dashDir * _dashSpeed * Time.deltaTime);
            yield return null;
        }
        _isDashing = false;
        _lookAtMousePos = true;
        StartCoroutine(nameof(RechargeDash));
    }

    IEnumerator RechargeDash()
    {
        _canDash = false;
        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }

    public void ResetCooldowns()
    {
        _canDash = true;
        _isDashing = false;
        _attackController.ResetCooldowns();
        Debug.Log("Reset all cooldowns apart form UltimateSkill");
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(mousePos,0.1f);
        Gizmos.DrawLine(transform.position, mousePos);
        
        Gizmos.color = Color.green;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.22f);
    }
}


