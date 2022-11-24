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

    void ResetTeleport()
    {
        foreach (Transform teleportObject in _teleportsObjects)
        {
            teleportObject.GetComponent<TeleportPointsScript>().StartCoroutine("ResetTeleport");
        }
    }
}
