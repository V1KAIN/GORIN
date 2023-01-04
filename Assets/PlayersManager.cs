using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _connectedPlayers;
    [SerializeField] private List<Transform> _PlayersSpawnPoints;
    [SerializeField] [Range(1,10)] private int _neededPlayersToLaunch;
    
    //Use to launch game
    public static bool _enoughPlayersConnected;


    private void GetPlayerToSpawnPos()
    {
        
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
