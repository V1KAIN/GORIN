using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    public GameObject CasterObject;
    [SerializeField] private float _lifeTime = 7f;
    [SerializeField] private int _damage = 20;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        gameObject.transform.SetParent(CasterObject.transform);
    }
}
