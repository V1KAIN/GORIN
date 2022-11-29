using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Orb : MonoBehaviour
{
    private GameObject _orbSpawner; private bool _taken;

    private void Start()
    {
        _taken = false;
    }

    protected abstract void OrbEffect(GameObject toAffect);
    public abstract void OrbVisualEffectTaken();
    public abstract void OrbVisualEffectSpawn();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Killable") && other.GetComponent<CharacterController>() && !_taken)
        {
            _taken = true;
            OrbEffect(other.gameObject);
            OrbVisualEffectTaken();
        }   
    }
}
