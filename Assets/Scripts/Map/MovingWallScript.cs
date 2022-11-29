using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallScript : MonoBehaviour
{
    [HideInInspector]public bool _isWallUp;
    
    IEnumerator SetWallUp()
    {
        _isWallUp = false;
        //Wait for animation time
        yield return new WaitForSeconds(.1f);
        _isWallUp = true;
    }

    IEnumerator SetWallDown()
    {
        _isWallUp = true;
        //Wait for animation time

        yield return new WaitForSeconds(.1f);
        _isWallUp = false;
    }
}
