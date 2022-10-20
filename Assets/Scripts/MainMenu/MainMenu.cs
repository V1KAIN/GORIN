using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerGORIN networkManager = null;

    [Header("UI")]
    [SerializeField] private List<GameObject> landingPagePanel = null;

    public void HostLobby()
    {
        networkManager.StartHost();
        foreach (GameObject obj in landingPagePanel)
        {
            obj.SetActive(false);
        }
    }
}
