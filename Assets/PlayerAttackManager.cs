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
    }

    void GetPlayerInputs()
    {
        if (!_isAttacking)
        {
            if (Input.GetKeyDown(_attackSpellKey)) { CastSpell(1); }
            if (Input.GetKeyDown(_supportSpellKey)) { CastSpell(2); }
            if (Input.GetKeyDown(_UltimateSpellKey)) { CastSpell(3); }

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
                if (_haveFireball)
                {
                    _playerModelAnimator.PlayFireballCastAnimation();
                    StartCoroutine(nameof(FireballCooldown));
                }
                break;
            case 2:
                Debug.Log("Casted SupportSpell");
                break;
            case 3:
                Debug.Log("Casted UltimateSpell");
                break;
        }
    }

    [Header("Cooldowns")]
    [SerializeField] private float _normalSlashCD;
    [SerializeField] private bool _isAttacking = false;
    
    [SerializeField] private float _fireballCD;
    [SerializeField] private bool _haveFireball = true;
    private IEnumerator SlashCooldown()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(_normalSlashCD);
        _isAttacking = false;
    } 
    
    private IEnumerator FireballCooldown()
    {
        _haveFireball = false;
        yield return new WaitForSeconds(_fireballCD);
        _haveFireball = true;
    }
}
