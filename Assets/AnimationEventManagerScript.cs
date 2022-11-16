using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _fireballSpawnPoint;
    [SerializeField] private GameObject _playerObject;
    
     
    public void LaunchFireBall()
    {
        Vector3 dir = _playerObject.transform.forward;
        Quaternion fireballRot =  _fireballSpawnPoint.transform.rotation;
        fireballRot.x = 0;
        fireballRot.z = 0;

        GameObject fireball = Instantiate(_fireballPrefab, _fireballSpawnPoint.transform.position, fireballRot);
    }
    
}
