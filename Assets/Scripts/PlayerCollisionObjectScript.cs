using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionObjectScript : MonoBehaviour
{
    [SerializeField] private Collider _curObjectCollider;
    private PlayerCollisionController _collisionManager;

    public Action HasBeenHit;
    
    private void Start()
    {
        _collisionManager = GetComponentInParent<PlayerCollisionController>();
        _collisionManager._playerCombatCollisionObjects.Add(this);
    }

    private void Update()
    {
        _curObjectCollider.enabled = GetComponent<PlayerCollisionObjectScript>().isActiveAndEnabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasBeenHit?.Invoke();
        }
    }
}
