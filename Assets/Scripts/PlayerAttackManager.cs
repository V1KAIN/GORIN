using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("PlayerInputSettings")] 
    [SerializeField] private KeyCode _attackSpellKey = KeyCode.R;
    [SerializeField] private KeyCode _supportSpellKey = KeyCode.F;
    [SerializeField] private KeyCode _UltimateSpellKey = KeyCode.W;
    
    
    
    private PlayerAnimationController _playerModelAnimator;
    

    private void Start()
    {
        _playerModelAnimator = GetComponent<PlayerAnimationController>();
        _isAttacking = false;
    }

    private void Update()
    {
        GetPlayerInputs();
        CheckUltimate();
    }

    void GetPlayerInputs()
    {
        if (!_isAttacking)
        {
            if (Input.GetKeyDown(_attackSpellKey)) { CastSpell(1); }
            if (Input.GetKeyDown(_supportSpellKey)) { CastSpell(2); }
            if (Input.GetKeyDown(_UltimateSpellKey) && _haveUltimateSpell) { CastSpell(3); }

            if (Input.GetButtonDown("Fire1"))
            {
                _playerModelAnimator.PlayAttackAnimation();
                StartCoroutine(nameof(SlashCooldown));
            }
        }
    }

    //1 = AttackSpell || 2 = SupportSpell || 3 = UltimateSpell
    private void CastSpell(int spellId)
    {
        switch (spellId)
        {
            case 1:
                Debug.Log("Casted AttackSpell");
                if (_haveAttackSpell)
                {
                    _playerModelAnimator.PlayFireballCastAnimation();
                    StartCoroutine(nameof(FireballCooldown));
                }
                break;
            case 2:
                Debug.Log("Casted SupportSpell");
                break;
            case 3:
                _playerModelAnimator.PlayTornadoAnimation();
                Debug.Log("Casted UltimateSpell");
                break;
        }
    }

    [Header("Cooldowns")]
    [SerializeField] private float _normalSlashCD;
    [SerializeField] private bool _isAttacking = false;
    [SerializeField] private float _fireballCD;
    
    [Space]
    [SerializeField] private bool _haveAttackSpell = true;
    [SerializeField] private bool _haveSupportSpell = true;
    [SerializeField] private bool _haveUltimateSpell = true;

    [SerializeField] private int _ultimatePointsNeeded; 
    private bool _canUseUltimate = false;
    private IEnumerator SlashCooldown()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(_normalSlashCD);
        _isAttacking = false;
    } 
    
    private IEnumerator FireballCooldown()
    {
        _haveAttackSpell = false;
        yield return new WaitForSeconds(_fireballCD);
        _haveAttackSpell = true;
    }

    private int _ultimatePoints;
    private void CheckUltimate()
    {
        if (_ultimatePoints >= _ultimatePointsNeeded)
        {
            _canUseUltimate = true;
        }
    }

    public void AddUltimatePoint()
    {
        _ultimatePoints++;
    }

    public void ConsumeOneUltimatePoint()
    {
        _ultimatePoints--;
    }

    public void UseAllUltimatePoints()
    {
        _ultimatePoints = 0;
    }   
    
    public void ResetCooldowns()
    {
        StopAllCoroutines();
        _isAttacking = false;
        _haveAttackSpell = true;
        _haveSupportSpell = true;
    }
}
