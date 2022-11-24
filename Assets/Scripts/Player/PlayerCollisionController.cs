using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public List<PlayerCollisionObjectScript> _playerCombatCollisionObjects;
    public bool _combatCollisionActive;
    
    private void Update()
    {
        if (_playerCombatCollisionObjects == null)
        {
            Debug.LogWarning("No Collider in Player combat collision list");
            return;
        }
        
        ManageCombatCollisionState();
        UpdateHitCall();
    }

    void ManageCombatCollisionState()
    {
        foreach (PlayerCollisionObjectScript objCol in _playerCombatCollisionObjects)
        {
            objCol.enabled = _combatCollisionActive;
        }
    }

    void UpdateHitCall()
    {
        foreach (var t in _playerCombatCollisionObjects)
        {
            t.HasBeenHit += CheckForHit;
        }
    }

    void CheckForHit()
    {
        
    }
}
