using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
   [SerializeField] private float _fireballTravelSpeed;
   
   private void Update()
   {
      transform.position += transform.forward * Time.deltaTime * _fireballTravelSpeed;
   }
}
