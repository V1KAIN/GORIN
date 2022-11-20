using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AnimationEventManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _playerCaster;
    
    [Header("Fireball")]
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _fireballSpawnPoint;

    [Header("Tornado")] 
    [SerializeField] private GameObject _tornadoPrefab;
    [SerializeField] private GameObject _tornadoSpawnPoint;
    
    
     
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
        tornado.transform.SetParent(_playerCaster.transform);
    }
}
