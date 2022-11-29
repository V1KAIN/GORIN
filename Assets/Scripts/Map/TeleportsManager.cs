using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportsManager : MonoBehaviour
{
    public List<Transform> _teleportsObjects;

    public Transform GetTarget(Transform fromPoint)
    {
        List<Transform> availablePoints = new List<Transform>();

        foreach (Transform point in _teleportsObjects)
        {
            if (point != fromPoint) { availablePoints.Add(point); }
        }

        int randomPoint = Random.Range(0, availablePoints.Count);
        Debug.Log( " random tp from " + fromPoint.name + " to " +  availablePoints[randomPoint].name);
        fromPoint.GetComponent<TeleportPointsScript>().PlayEffect();
        availablePoints[randomPoint].GetComponent<TeleportPointsScript>().PlayEffect();
        ResetTeleport();
        return availablePoints[randomPoint];
    }
    
    public Transform GetTargetWithoutOrigin()
    {
        int randomPoint = Random.Range(0, _teleportsObjects.Count);
        _teleportsObjects[randomPoint].GetComponent<TeleportPointsScript>().PlayEffect();
        RefreshTeleport();
        return _teleportsObjects[randomPoint];
    }

    void ResetTeleport()
    {
        foreach (Transform teleportObject in _teleportsObjects)
        {
            teleportObject.GetComponent<TeleportPointsScript>().StartCoroutine("ResetTeleport");
        }
    }

    void RefreshTeleport()
    {
        foreach (Transform tpPoint in _teleportsObjects)
        {
            tpPoint.GetComponent<TeleportPointsScript>().StartCoroutine("MiniRefreshTeleport");
        }
    }
}
