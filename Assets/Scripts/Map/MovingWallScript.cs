using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallScript : MonoBehaviour
{
    public bool _isWallUp;
    [SerializeField] private Animator _wallAnimator;
    [SerializeField] private GameObject _movingWallManager;

    private void Start()
    {
        _movingWallManager.GetComponent<MovingWallsManager>().MovingWallsInScene.Add(gameObject);
    }

    public IEnumerator SetWallUp()
    {
        _isWallUp = false;
        //Wait for animation time
        _wallAnimator.SetTrigger("GetWallUp");
        yield return new WaitForSeconds(.25f);
        _isWallUp = true;
    }

    public IEnumerator SetWallDown()
    {
        _isWallUp = true;
        //Wait for animation time
        _wallAnimator.SetTrigger("GetWallDown");
        yield return new WaitForSeconds(.25f);
        _isWallUp = false;
    }
}
