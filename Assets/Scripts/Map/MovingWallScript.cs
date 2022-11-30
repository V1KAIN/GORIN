using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallScript : MonoBehaviour
{
    [HideInInspector]public bool _isWallUp;
    [SerializeField] private Animator _wallAnimator;
    [SerializeField] private GameObject _movingWallManager;
    
    public IEnumerator SetWallUp()
    {
        _isWallUp = false;
        //Wait for animation time
        yield return new WaitForSeconds(.1f);
        _isWallUp = true;
    }

    public IEnumerator SetWallDown()
    {
        _isWallUp = true;
        //Wait for animation time

        yield return new WaitForSeconds(.1f);
        _isWallUp = false;
    }
}
