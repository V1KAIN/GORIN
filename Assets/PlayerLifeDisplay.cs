using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _lifeFillObject;
    

    private void Update()
    {
        UpdatePlayerLife();
    }

    void UpdatePlayerLife()
    {
        float playerLifeToDisplay = (_playerObject.GetComponent<KillableObject>().ObjectCurLife * 1);
        playerLifeToDisplay = playerLifeToDisplay / _playerObject.GetComponent<KillableObject>().ObjectBaseLife;
        Debug.Log(playerLifeToDisplay);
        _lifeFillObject.transform.localScale = new Vector3(playerLifeToDisplay, 1,1);
    }
}
