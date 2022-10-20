using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkRoomPlayerGORIN : NetworkBehaviour
{
   [Header("UI")] 
   [SerializeField] private GameObject lobbyUI = null;
   [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[2];
   [SerializeField] private TMP_Text[] playerReadyTexts = new TMP_Text[2];
   [SerializeField] private Button startGameButton = null;

   //[SyncVar(hook = nameof(HandleDisplayNameChanged))]
   public string DisplayName;

   //[SyncVar(hook = nameof(HandleReadyStatusChange))]
   public bool IsReady = false;

   private bool isLeader;

  // public bool IsLeader() {}
  //6:18
}
