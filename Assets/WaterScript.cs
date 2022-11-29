using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterScript : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _respawnTime = 2;
    [SerializeField] private GameObject _teleportManagerObject;
    
    
    
    //Private
   private TeleportsManager _teleportManager;

   private void Start()
   {
       _teleportManager = _teleportManagerObject.GetComponent<TeleportsManager>();
   }

   void WaterEffectOnPlayer(GameObject player)
   {
        player.GetComponent<KillableObject>().TakeDamage(_damage);
        player.GetComponent<CharacterController>().enabled = false;
        Vector3 newPos = _teleportManager.GetTargetWithoutOrigin().position;
        player.transform.position = newPos;
        player.GetComponent<CharacterController>().enabled = true;
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.GetComponent<CharacterController>())
       {
           WaterEffectOnPlayer(other.gameObject);
       }
   }
}
