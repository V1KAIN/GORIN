using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AnimationEventManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _playerCaster;

    [Header("FootEffect")] 
    [SerializeField] private GameObject _stepEffect;
    [SerializeField] private GameObject _leftFootPos;
    [SerializeField] private GameObject _rightFootPos;
    
    [Header("Fireball")]
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _fireballSpawnPoint;
    [Header("Tornado")] 
    [SerializeField] private GameObject _tornadoPrefab;
    [SerializeField] private GameObject _tornadoSpawnPoint;
    [Header("Shield")] 
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private GameObject _shieldSpawnPoint;
    
    
     
    public void LaunchFireBall()
    {
        Quaternion fireballRot =  _fireballSpawnPoint.transform.rotation;
        fireballRot.x = 0;
        fireballRot.z = 0;

        GameObject fireball = Instantiate(_fireballPrefab, _fireballSpawnPoint.transform.position, fireballRot);
    }

    public void LaunchTornado()
    {
        GameObject tornado = Instantiate(_tornadoPrefab, _tornadoSpawnPoint.transform.position, quaternion.identity);
        tornado.GetComponent<TornadoScript>().CasterObject = _playerCaster;
        
    }

    public void CreateShield()
    {
        GameObject shield = Instantiate(_shieldPrefab, _shieldSpawnPoint.transform.position, quaternion.identity);
        shield.GetComponent<ReinforceScript>()._playerObject = _playerCaster;
    }

    public void RightFootEffect()
    {
        //GameObject walkEffect = Instantiate(_stepEffect, _rightFootPos.transform.position, quaternion.identity);
    }

    public void LeftFootEffect()
    {
        //GameObject walkEffect = Instantiate(_stepEffect, _leftFootPos.transform.position, quaternion.identity);
    }
}
