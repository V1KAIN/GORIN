using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] private LayerMask _groundLayer;
    
    [Space]
    //Privates
    float _curSpeed;
    CharacterController _characterController;
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
        _curSpeed = _walkingSpeed;

        _playerModelAnimator = GetComponent<PlayerAnimationController>();
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

        if (!_isDashing)
        {
            _characterController.Move(_moveDir);
        }
    }
    
    void GetPlayerInputs()
    {
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            GetSpeedByInputs();
        }
        else
        {
            _pInputs.x = (_curSpeed / 100 ) * Input.GetAxis("Horizontal");
            _pInputs.z = (_curSpeed / 100 ) * Input.GetAxis("Vertical");
        }

        
        
        if (Input.GetButtonDown("Jump") && _canDash && !_isDashing)
        {
            StartCoroutine(nameof(Dash));
            transform.rotation = _rotGoal;
            _dashDir = transform.forward;
            _canDash = false;
        }
    }
    
    void GetSpeedByInputs()
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

    Vector3 mousePos = Vector3.zero;
    private Quaternion _rotGoal;
    private Vector3 _lookAtDir;
    void LookAtMousePosition()
    {
        Ray mousePosRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mousePosRay, out RaycastHit hit, float.MaxValue, _groundLayer))
        {
            mousePos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        
        _lookAtDir = (mousePos - transform.position).normalized;
        _rotGoal = Quaternion.LookRotation(_lookAtDir); _rotGoal.x = 0; _rotGoal.z = 0;
        if(_lookAtMousePos)transform.rotation = Quaternion.Slerp(transform.rotation, _rotGoal, _playerLookAtSpeed);
    }

    private Vector3 _dashDir = new Vector3();
    IEnumerator Dash()
    {
        _isDashing = true;
        _canDash = false;
        _lookAtMousePos = false;
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


