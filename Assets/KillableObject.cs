using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KillableObject : MonoBehaviour
{
    [SerializeField]protected int ObjectBaseLife = 200;
    protected int ObjectCurLife;

    private void Start()
    {
        ObjectCurLife = ObjectBaseLife;
    }

    private void Update()
    {
        CheckDeath();
    }

    public void TakeDamage(int value)
    {
        ObjectCurLife -= value;
        Debug.Log(gameObject.name + " lose " + value + " health points");
        Debug.Log("Updated to " + ObjectCurLife + " health points");
    }

    public void GetLifeBack(int value)
    {
        ObjectCurLife += value;
        Debug.Log(gameObject.name + " get " + value + " health points back");
        Debug.Log("Updated to " + ObjectCurLife + " health points");
    }

    public void CheckDeath()
    {
        if (ObjectCurLife <= 0)
        {
            ObjectDie();
        }
    }

    public void ObjectDie()
    {
        DeathEffect();
    }

    public abstract void DeathEffect();
    
}
