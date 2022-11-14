using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KillableObject
{
    protected int ObjectBaseLife = 200;
    protected int ObjectCurLife;

    public void TakeDamage() {}
    public void GetLifeBack() {}

    public abstract void DieEffect();
}
