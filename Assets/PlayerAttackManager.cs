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
    private bool _isAttacking = false;

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
        if (Input.GetKeyDown(_attackSpellKey)) { CastSpell(1); }
        if (Input.GetKeyDown(_supportSpellKey)) { CastSpell(2); }
        if (Input.GetKeyDown(_UltimateSpellKey)) { CastSpell(3); }
        
        if (Input.GetButtonDown("Fire1")) { _playerModelAnimator.PlayAttackAnimation();}
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
