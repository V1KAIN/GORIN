using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTeleportPortalScript : MonoBehaviour
{
    [SerializeField] private List<Transform> _teleportCoordinates = new List<Transform>();
    [SerializeField] private float _timeToReset = 3f;

    private bool _portalsAreWorking = true;
    private float _portalsRemainingCooldown = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LookForTeleportPoint();
        }

        if (!_portalsAreWorking)
        {
            _portalsRemainingCooldown -= Time.deltaTime;
            if (_portalsRemainingCooldown <= 0)
            {
                _portalsAreWorking = true;
                _portalsRemainingCooldown = _timeToReset;
            }
        }
    }

    private void LookForTeleportPoint()
    {
        if (_portalsAreWorking)
        {
            
        }
    }
}
