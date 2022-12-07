using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinScript : KillableObject
{
    public override void DeathEffect()
    {
        Debug.Log(gameObject.name + " is dead");
        
        GetComponent<SwitchToDissolveScript>().SwitchALLToDissolveMaterial();
        DissolveObject();
    }
    
    void DissolveObject()
    {
        GetComponent<SwitchToDissolveScript>().StartCoroutine("StartFadeOut");
    } 
    
    
}
