using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToDissolveScript : MonoBehaviour
{
   [SerializeField] private List<MeshRenderer> _toChangeMaterial;
   [SerializeField] private Material _newMaterial;
   
   private float dAmount;
   private void Update()
   {
      
   }

   [ContextMenu("SwitchAll")]
   public void SwitchALLToDissolveMaterial()
   {
      foreach (MeshRenderer renderer in _toChangeMaterial)
      {
         renderer.material = _newMaterial;
      }
   }

   public float dissolveSpeed;
   
   
   public IEnumerator StartFadeOut()
   {
      foreach (MeshRenderer renderer in _toChangeMaterial)
      {
         dAmount = Mathf.Lerp(0,1, Time.deltaTime * dissolveSpeed);
         renderer.material.SetFloat("_DissolveAmount", dAmount) ;
      }
      yield return new WaitForSeconds(1);
      Destroy(gameObject);
   }
}
