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

   [SyncVar(hook = nameof(HandleDisplayNameChanged))]
   public string DisplayName;

   [SyncVar(hook = nameof(HandleReadyStatusChange))]
   public bool IsReady = false;

   private bool _isLeader;

   public bool IsLeader
   {
      set
      {
         _isLeader = value;
         startGameButton.gameObject.SetActive(value);
      }
   }

   private NetworkManagerGORIN room;

   private NetworkManagerGORIN Room
   {
      get
      {
         if (room != null) { return room; }
         return room = NetworkManager.singleton as NetworkManagerGORIN;
      }
   }

   public override void OnStartAuthority()
   {
      CmdSetDisplayName(PlayerNameInput.DisplayName);
      lobbyUI.SetActive(true);
   }

   public override void OnStartClient()
   {
      Room.RoomPlayers.Add(this);
      UpdateDisplay();
   }

   public override void OnStopClient()
   {
      Room.RoomPlayers.Remove(this);

      UpdateDisplay();
   }

   public void HandleReadyStatusChange(bool oldValue, bool newValue) => UpdateDisplay();

   public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();

   private void UpdateDisplay()
   {
      if (!isLocalPlayer)
      {
         foreach (var player in Room.RoomPlayers)
         {
            if (player.isLocalPlayer)
            {
               player.UpdateDisplay();
               break;
            }
         }
         return;
      }

      for (int i = 0; i < playerNameTexts.Length; i++)
      {
         
      }
   }
   //9:42
}
