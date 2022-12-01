using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallsManager : MonoBehaviour
{
    public List<GameObject> MovingWallsInScene;
    private bool _wallsAreUp;


    private void Start()
    {
        _wallsAreUp = false;
    }

    public void WallsGoUp()
    {
        _wallsAreUp = true;
        foreach (GameObject wall in MovingWallsInScene)
        {
            Debug.Log( wall.name +" is going up");
            
            if (wall.GetComponent<MovingWallScript>()._isWallUp == false)
            {
                wall.GetComponent<MovingWallScript>().StartCoroutine("SetWallUp");    
            }
        }
    }

    public void WallsGoDown()
    {
        _wallsAreUp = false;
        foreach (GameObject wall in MovingWallsInScene)
        {
            Debug.Log( wall.name +" is going down");
            
            if (wall.GetComponent<MovingWallScript>()._isWallUp)
            {
                wall.GetComponent<MovingWallScript>().StartCoroutine("SetWallDown");    
            }
            
        }
    }

    public void ChangeWallState()
    {
        if (_wallsAreUp == false) { WallsGoUp(); }
        else if (_wallsAreUp) { WallsGoDown(); }
    }
}
