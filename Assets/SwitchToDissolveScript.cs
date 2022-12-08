using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToDissolveScript : MonoBehaviour
{
   [SerializeField] private List<MeshRenderer> _toChangeMaterial;
   [SerializeField] private Material _newMaterial;

   private List<Material> newMatOnObject = new List<Material>();

   [ContextMenu("SwitchAll")]
   public void SwitchALLToDissolveMaterial()
   {
      foreach (MeshRenderer renderer in _toChangeMaterial)
      {
         renderer.material = _newMaterial;
         newMatOnObject.Add(renderer.material);
      }
   }
   
   public MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
   
   public IEnumerator StartFadeOut()
   {
      yield return new WaitForSeconds(.01f);
      float t = 0;
      while (t < 1f)
      {
         t += Time.deltaTime ;
         //propertyBlock.SetFloat("_DissolveAmount", t);
         for (int i = 0; i < _toChangeMaterial.Count; i++)
         {
//            _toChangeMaterial[i].SetPropertyBlock(propertyBlock);
               newMatOnObject[i].SetFloat("_DissolveAmount" ,t);
            
         }
         yield return null;
      }
      Destroy(gameObject);
   }
}
