using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : KillableObject 
{
    public override void DeathEffect()
    {
        GetComponent<PlayerAnimationController>().PlayDeadAnimation();
        
        GetComponent<CharacterController>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerAttackManager>().enabled = false;
    }
}
