using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOrbScript : Orb
{
    [SerializeField] private int _healValue;
    
    protected override void OrbEffect(GameObject toAffect)
    {
        toAffect.GetComponent<KillableObject>().GetLifeBack(_healValue);
        Debug.Log("Healed " + toAffect.name + " for " + _healValue + " HP");
    }

    public override void OrbVisualEffectTaken()
    {
        
    }

    public override void OrbVisualEffectSpawn()
    {
        
    }
}
