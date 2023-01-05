using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _connectedPlayers;
    [SerializeField] private List<Transform> _PlayersSpawnPoints;
    [SerializeField] [Range(1,10)] private int _neededPlayersToLaunch;
    
    //Use to launch game
    public static bool _enoughPlayersConnected;
    int currentSpawnedPlayers = 0;

    public void Update()
    {
        if (currentSpawnedPlayers == _neededPlayersToLaunch)
        {
            _enoughPlayersConnected = true;
        }
        
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        if (currentSpawnedPlayers < _connectedPlayers.Count)
        {
            GetPlayerToSpawnPos(_connectedPlayers[^1]);
            currentSpawnedPlayers = _connectedPlayers.Count;
        }
    }

    public void StartPlayers()
    {
        foreach (GameObject player in _connectedPlayers)
        {
            player.GetComponent<PlayerConnectScript>().PlayerStartPlay();
        }
    }

    private void GetPlayerToSpawnPos(GameObject playerToSpawn)
    {
        playerToSpawn.transform.position = _PlayersSpawnPoints[_connectedPlayers.IndexOf(playerToSpawn)].position;
    }
    
    public void ConnectPlayer(GameObject playerToConnect)
    {
        _connectedPlayers.Add(playerToConnect);
    }

    public void DisconnectPlayer(GameObject playerToDisconnect)
    {
        _connectedPlayers.Remove(playerToDisconnect);
    }
}
