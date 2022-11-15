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

    [Header("PlayerInputSettings")] 
    [SerializeField] private KeyCode _attackSpellKey = KeyCode.R;
    [SerializeField] private KeyCode _supportSpellKey = KeyCode.F;
    [SerializeField] private KeyCode _UltimateSpellKey = KeyCode.W;


    [Header("Player Settings")] 
    [SerializeField] private float _playerLookAtSpeed = .2f;
    [SerializeField] private PlayerAnimationController _playerModelAnimator;
    
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

        if (Input.GetKeyDown(_attackSpellKey)) { CastSpell(1); }
        if (Input.GetKeyDown(_supportSpellKey)) { CastSpell(2); }
        if (Input.GetKeyDown(_UltimateSpellKey)) { CastSpell(3); }

        if (Input.GetButtonDown("Jump") && _canDash && _isDashing == false)
        {
            StartCoroutine(nameof(Dash));
            _dashDir = transform.forward;
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
        if (Physics.Raycast(mousePosRay, out RaycastHit hit))
        {
            mousePos = new Vector3(hit.point.x, transform.localPosition.y, hit.point.z);
        }

        _lookAtDir = (mousePos - transform.position).normalized;
        _rotGoal = Quaternion.LookRotation(_lookAtDir);
        if(_lookAtMousePos)transform.rotation = Quaternion.Slerp(transform.rotation, _rotGoal, _playerLookAtSpeed);
    }

    private Vector3 _dashDir = new Vector3();
    IEnumerator Dash()
    {
        _isDashing = true;
        _canDash = false;
        _lookAtMousePos = false;
        float startTime = Time.time;

        while (Time.time < startTime + _dashTime)
        {
            Debug.Log("CurrentlyDashing");
            _characterController.Move(_dashDir * _dashSpeed * Time.deltaTime);
            yield return null;
        }
        _isDashing = false;
        _canDash = true;
        _lookAtMousePos = true;
        RechargeDash();
    }

    IEnumerator RechargeDash()
    {
        _canDash = false;
        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }

    //1 = AttackSpell || 2 = SupportSpell || 3 = UltimateSpell
    private void CastSpell(int spellId)
    {
        switch (spellId)
        {
            case 1:
                Debug.Log("Casted AttackSpell");
                _playerModelAnimator.PlayFireballCastAnimation();
                break;
            case 2:
                Debug.Log("Casted SupportSpell");
                break;
            case 3:
                Debug.Log("Casted UltimateSpell");
                break;
        }
    }
}
