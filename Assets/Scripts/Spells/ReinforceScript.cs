using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinforceScript : MonoBehaviour
{
    [SerializeField] private float _spellUpTime;
    public GameObject _playerObject;

    private void Start()
    {
        transform.SetParent(_playerObject.transform);
        Invoke(nameof(StopSpell), _spellUpTime);
        _playerObject.GetComponent<KillableObject>().IsReinforced = true;
    }
    
    void StopSpell()
    {
        _playerObject.GetComponent<KillableObject>().IsReinforced = false;
        _playerObject.GetComponent<PlayerAttackManager>().StartCoroutine("ReinforceCooldown");
        Destroy(gameObject, 0.05f);
    }
    
}
