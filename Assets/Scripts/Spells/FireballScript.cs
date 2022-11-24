using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
   [SerializeField] private float _fireballTravelSpeed;
   [SerializeField] private float _lifeTime = 5;
   [SerializeField] private int _damage = 50;
   [SerializeField] private GameObject _spellPreviewZone;
   private float lifeTimeLeft = 1;
   
   private void Start()
   {
      lifeTimeLeft = _lifeTime;
   }

   private void Update()
   {
      transform.position += transform.forward * Time.deltaTime * _fireballTravelSpeed;

      if (lifeTimeLeft >= 0) { lifeTimeLeft -= Time.deltaTime; }
      else
      {
         DestroyFireball();
      }
      
      AdaptPreviewZone();
   }

   private Vector3 newPreviewPos = new Vector3();
   void AdaptPreviewZone()
   {
      if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
      {
         newPreviewPos = new Vector3(transform.position.x, hit.transform.position.y + 0.1f, transform.position.z);
         _spellPreviewZone.transform.position = newPreviewPos;
      }
   }

   void DestroyFireball()
   {
      Destroy(gameObject);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag != "Killable")
      {
         Debug.Log("Ball touched " + other.name);
         DestroyFireball();
      }

      if (other.CompareTag("Killable"))
      {
         other.GetComponent<KillableObject>().TakeDamage(_damage);
         DestroyFireball();
      } 
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green;
      Gizmos.DrawLine(transform.position, newPreviewPos);
   }
}
