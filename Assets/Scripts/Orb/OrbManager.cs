using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrbManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _orbsToSpawnPrefabs;
    [SerializeField] private Transform _orbParent;
    [SerializeField] private float _respawnTime;

    protected GameObject _currentPlacedOrb;


    private void Start()
    {
        orbRespawnTimer = _respawnTime;
    }

    private void Update()
    {
        ManageOrbSpawn();
    }

    public void SpawnRandomOrb()
    {
        int randomOrb = Random.Range(0, _orbsToSpawnPrefabs.Count);

        _currentPlacedOrb = Instantiate(_orbsToSpawnPrefabs[randomOrb], _orbParent.position, quaternion.identity);
        _currentPlacedOrb.transform.SetParent(_orbParent);
    }


    private float orbRespawnTimer = 0;
    void ManageOrbSpawn()
    {
        if (_currentPlacedOrb == null)
        {
            orbRespawnTimer -= Time.deltaTime;
        }

        if (orbRespawnTimer <= 0)
        {
            SpawnRandomOrb();
            orbRespawnTimer = _respawnTime;
        }
    }
}
