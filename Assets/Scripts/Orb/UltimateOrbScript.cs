using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateOrbScript : Orb
{
    protected override void OrbEffect(GameObject toAffect)
    {
        toAffect.GetComponent<PlayerAttackManager>().AddUltimatePoint();
    }

    public override void OrbVisualEffectTaken()
    {
        Destroy(gameObject);
    }

    public override void OrbVisualEffectSpawn()
    {
        
    }
}
