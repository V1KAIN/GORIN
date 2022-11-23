using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPointsScript : MonoBehaviour
{
    [SerializeField] private GameObject _teleportEffect;
    [SerializeField] private float _effectTime = 0.3f;
    [SerializeField] private float _rechargeTime = 5;
    [SerializeField] private GameObject _teleportManager;

    //Privates
    [HideInInspector] public bool _canTeleport = true;
    
    private void Start()
    {
        _teleportManager = GameObject.FindWithTag("TeleportManager");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Killable") && _canTeleport)
        {
            TeleportToTarget(other.transform);
        }
        
    }

    private void TeleportToTarget(Transform toTeleport)
    {
        toTeleport.GetComponent<CharacterController>().enabled = false;
        Vector3 newPos = _teleportManager.GetComponent<TeleportsManager>().GetTarget(gameObject.transform).position;
        toTeleport.position = newPos;
        toTeleport.GetComponent<CharacterController>().enabled = true;
    }

    public IEnumerator ResetTeleport()
    {
        _canTeleport = false;
        yield return new WaitForSeconds(_rechargeTime);
        _canTeleport = true;
    }

    public void PlayEffect()
    {
        _teleportEffect.SetActive(true);
        Invoke(nameof(StopEffect), _effectTime);
    }

    void StopEffect()
    {
        _teleportEffect.SetActive(false);
    }
    
}
