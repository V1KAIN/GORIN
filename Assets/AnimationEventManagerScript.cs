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
        Quaternion fireballRot = _fireballSpawnPoint.transform.rotation;
        fireballRot.x = 0;
        fireballRot.z = 0;
        
        Instantiate(_fireballPrefab, _fireballSpawnPoint.transform.position, fireballRot);
    }
    
}
