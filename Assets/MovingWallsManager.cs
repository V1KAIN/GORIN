using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallsManager : MonoBehaviour
{
    public List<GameObject> MovingWallsInScene;
    [SerializeField] private bool _wallAreUp;


    public void WallsGoUp()
    {
        foreach (GameObject wall in MovingWallsInScene)
        {
            wall.GetComponent<MovingWallScript>().StartCoroutine("SetWallUp");
        }
        _wallAreUp = true;
    }

    public void WallsGoDown()
    {
        foreach (GameObject wall in MovingWallsInScene)
        {
            wall.GetComponent<MovingWallScript>().StartCoroutine("SetWallDown");
        }
        _wallAreUp = false;
    }
}
