using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    public GameObject CasterObject;

    private void Start()
    {
        gameObject.transform.SetParent(CasterObject.transform);
    }
}
