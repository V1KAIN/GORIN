using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KillableObject : MonoBehaviour
{
    public int ObjectBaseLife = 200;
    [SerializeField] public int ObjectCurLife;

    [HideInInspector]public bool IsDead = false;

    public bool IsReinforced;

    private void Start()
    {
        ObjectCurLife = ObjectBaseLife;
    }

    private void Update()
    {
        CheckDeath();
        RebaseLife();
    }

    public void TakeDamage(int value)
    {
        if (IsReinforced)
        {
            ObjectCurLife -= Mathf.RoundToInt(value * 0.40f);
            Debug.Log(gameObject.name + " lose " + Mathf.RoundToInt(value * 0.40f) + " health points");
        }
        else
        {
            ObjectCurLife -= value;    
            Debug.Log(gameObject.name + " lose " + value + " health points");
        }
        
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
        if (ObjectCurLife <= 0 && IsDead == false)
        {
            IsDead = true;
            ObjectDie();
        }
    }

    public void ObjectDie()
    {
        DeathEffect();
    }

    void RebaseLife()
    {
        if (ObjectCurLife > ObjectBaseLife)
        {
            ObjectCurLife = ObjectBaseLife;
            Debug.Log(name + " current life went over base life, rebase current health points to base points");
        }
    }

    public abstract void DeathEffect();
    
}
