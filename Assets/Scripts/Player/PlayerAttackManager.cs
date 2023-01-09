using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("PlayerInputSettings")]
    private PlayerAnimationController _playerModelAnimator;
    
    private void Start()
    {
        AssignVariables();
    }

    private void Update()
    {
        CheckUltimate();
    }

    
    public void OnAttackSkill(){if(!_isAttacking){CastSpell(1);}}
    public void OnSupportSkill(){if(!_isAttacking){CastSpell(2);}}
    public void OnUltimateSkill(){if(!_isAttacking &&  _canUseUltimate){CastSpell(3);}}

    public void OnBasicAttack()
    {
        if(!_isAttacking){
            int slashAnim = Random.Range(0, 100);
                
            if(slashAnim >= 50) _playerModelAnimator.PlayAttackOneAnimation();
            else _playerModelAnimator.PlayAttackTwoAnimation();
            StartCoroutine(nameof(SlashCooldown));}
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
                if (_haveSupportSpell)
                {
                    _haveSupportSpell = false;
                    _playerModelAnimator.PlayReinforceAnimation();
                }
                Debug.Log("Casted SupportSpell");
                break;
            case 3:
                _playerModelAnimator.PlayTornadoAnimation();
                UseAllUltimatePoints();
                Debug.Log("Casted UltimateSpell");
                break;
        }
    }

    [Header("Cooldowns")]
    [SerializeField] private float _normalSlashCD;
    [SerializeField] private bool _isAttacking = false;
    public float _fireballCD;
    public float _reinforceCD;
    
    [Space]
    [SerializeField] private bool _haveAttackSpell = true;
    [SerializeField] private bool _haveSupportSpell = true;

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

    public IEnumerator ReinforceCooldown()
    {
        _haveSupportSpell = false;
        yield return new WaitForSeconds(_reinforceCD);
        _haveSupportSpell = true;
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
        _canUseUltimate = false;
    }   
    
    public void ResetCooldowns()
    {
        StopAllCoroutines();
        _isAttacking = false;
        _haveAttackSpell = true;
        _haveSupportSpell = true;
    }

    public void AssignVariables()
    {
        _playerModelAnimator = GetComponent<PlayerAnimationController>();
        _isAttacking = false;
    }
}
