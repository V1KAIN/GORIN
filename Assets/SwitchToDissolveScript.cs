using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToDissolveScript : MonoBehaviour
{
   [SerializeField] private List<MeshRenderer> _toChangeMaterial;
   [SerializeField] private Material _newMaterial;
   
   
   
   [ContextMenu("SwitchAll")]
   public void SwitchALLToDissolveMaterial()
   {
      foreach (MeshRenderer renderer in _toChangeMaterial)
      {
         renderer.material = _newMaterial;
      }
   }
}
