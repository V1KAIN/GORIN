using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerGORIN networkManager = null;

    [Header("UI")] 
    [SerializeField] private GameObject landingPagePanel = null;
    [SerializeField] private TMP_InputField ipAddressInputField = null;
    [SerializeField] private Button joinButton = null;

    private void OnEnable()
    {
        NetworkManagerGORIN.OnClientConnected += HandleClientConnected;
        NetworkManagerGORIN.OnClientConnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        
    }

    void HandleClientConnected(){}
    void HandleClientDisconnected(){}
}
