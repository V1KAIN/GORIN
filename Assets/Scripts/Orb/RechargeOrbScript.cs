using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeOrbScript : Orb
{
    protected override void OrbEffect(GameObject toAffect)
    {
        toAffect.GetComponent<PlayerController>().ResetCooldowns();
    }

    public override void OrbVisualEffectTaken()
    {
        Destroy(gameObject);
    }

    public override void OrbVisualEffectSpawn()
    {
        
    }
}
