using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusOrbSpawner : MonoBehaviour
{
    [Header("Orb Options")]
    [SerializeField] private OrbType _OrbType;
    [SerializeField] private List<GameObject> _orbPrefabs; 
    
    [Header("Respawn Options")]
    [SerializeField]private float _respawnTime;
    [SerializeField]private bool _canRespawn;
    [SerializeField]private bool _randomRespawn;
    [SerializeField]private List<Transform> _respawnPoints;
    
    //Privates
    private enum OrbType { Support, Ultimate}
    
    

    private void Respawn()
    {
        if (_canRespawn)
        {
            if (_OrbType == OrbType.Support)
            {
                Invoke(nameof(InstantiateOrb), _respawnTime);    
            }
            else
            {
                
            }   
        }
    }

    void InstantiateOrb()
    {
        
    }

    void CancelRespawn()
    {
        CancelInvoke();
    }
}
