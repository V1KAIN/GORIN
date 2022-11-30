using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageScript : MonoBehaviour
{
    [SerializeField] private int _damageValueOnCollision;
    [SerializeField] private List<GameObject> _toAvoidDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Killable") && !_toAvoidDamage.Contains(other.gameObject))
        {
            other.GetComponent<KillableObject>().TakeDamage(_damageValueOnCollision);
        }
    }
}
