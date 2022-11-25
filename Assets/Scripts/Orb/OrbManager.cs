using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    [Header("Map Options")]
    [SerializeField] private List<Transform> _supportOrbSpawnerPoints;
    [SerializeField] private List<Transform> _ultimateOrbSpawnerPoints;
    
    [Header("Orbs")]
    [SerializeField] private List<GameObject> _supportOrbsPrefabs;
    [SerializeField] private GameObject _ultimateOrbPrefab;

    [Header("Options")]
    [SerializeField] private bool _canRespawn = true;
    [SerializeField] private float _respawnDelay = 8f;
    [SerializeField] private float _ultimateOrbRespawnTime = 15f;

    private List<GameObject> _currentActiveOrbs;


    private float _supportTimer = 0f;
    private float _ultimateTimer = 0f;
    private void Update()
    {
        _supportTimer += Time.deltaTime;
        _ultimateTimer += Time.deltaTime;

        if (_supportTimer >= _respawnDelay)
        {
            foreach (GameObject orb in _currentActiveOrbs)
            {
                Destroy(orb);
            }
            
            foreach (Transform point in _supportOrbSpawnerPoints)
            {
                SpawnRandomSupportOrb(point);    
            }
        }
        
        if (_ultimateTimer >= _ultimateOrbRespawnTime)
        {
            foreach (GameObject orb in _currentActiveOrbs)
            {
                Destroy(orb);
            }
            
            foreach (Transform point in _supportOrbSpawnerPoints)
            {
                SpawnRandomSupportOrb(point);    
            }
        }
        
        for (int i = 0; i < _currentActiveOrbs.Count; i++)
        {
            if (_currentActiveOrbs[i] == null)
            {
                _currentActiveOrbs.Remove(_currentActiveOrbs[i]);
            }
        }
    }

    public void SpawnRandomSupportOrb(Transform spawnPos)
    {
        
    }

    public void SpawnUltimateOrb()
    {
        
    }
    
    
    
}
