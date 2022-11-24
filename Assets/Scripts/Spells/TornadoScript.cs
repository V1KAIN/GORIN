using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    public GameObject CasterObject;
    [SerializeField] private float _lifeTime = 7f;
    [SerializeField] private float _timeBetweenDamages = 2.5f;
    
    
    
    [SerializeField] private int _damage = 20;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        timer = 2.5f;
        gameObject.transform.SetParent(CasterObject.transform);
    }

    private float timer;
    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = _timeBetweenDamages;
            DealDamage();
        }
        
    }


    public List<GameObject> _dealDamageTo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KillableObject>() && other.transform != CasterObject.transform)
        {
            _dealDamageTo.Add(other.transform.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<KillableObject>() && other.transform != CasterObject.transform)
        {
            if (_dealDamageTo.Contains(other.transform.gameObject))
            {
                _dealDamageTo.Remove(other.transform.gameObject);
            } 
        }
    }

    void DealDamage()
    {
        if (_dealDamageTo != null)
        {
            foreach (GameObject toReceiveDamage in _dealDamageTo)
            {
                toReceiveDamage.GetComponent<KillableObject>().TakeDamage(_damage);
            }
        }
    }
    
    
}
