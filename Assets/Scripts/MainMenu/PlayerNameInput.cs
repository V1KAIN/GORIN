using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private List<Button> toDisable = null;
    
    public static string DisplayName { get; private set;}

    private const string PlayerPrefNameKey = "PlayerName";

    void Start() => SetupInputField();

    void SetupInputField()
    {
        if(!PlayerPrefs.HasKey(PlayerPrefNameKey)){return;}

        string defaultName = PlayerPrefs.GetString(PlayerPrefNameKey);
        nameInputField.text = defaultName;
        SetPlayerName(defaultName);
    }

    void SetPlayerName(string playerName)
    {
        foreach (var t in toDisable)
        {
            t.interactable = !string.IsNullOrEmpty(name);
        }
    }

    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;
        PlayerPrefs.SetString(PlayerPrefNameKey, DisplayName);
    }

    public void DeleteCurrentSavedName()
    {
        PlayerPrefs.DeleteKey(PlayerPrefNameKey);
    }
}
