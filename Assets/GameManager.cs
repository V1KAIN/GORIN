using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTimer = 0;
    [SerializeField] private float roundTime = 120; // In seconds
    
    //Private 
    private bool _isInStartTransition;
    private bool _gameIsPlaying;
    
    private void Start()
    {
        _isInStartTransition = false;
        _gameIsPlaying = false;
    }

    private void Update()
    {
        CheckForGameStart();    
    }

    void CheckForGameStart()
    {
        if (PlayersManager._enoughPlayersConnected && !_isInStartTransition && !_gameIsPlaying)
        {
            StartGame();
        }   
    }
    
    void StartGame()
    {
        _isInStartTransition = true;
    }
}
