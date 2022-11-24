using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrailScript : MonoBehaviour
{
    [Header("Effect")]
    [SerializeField] Material _effectMaterial;
    
    [Header("Trail Options")]
    [SerializeField] private float _meshFrameRate;
    [SerializeField] private float _meshDestroyDelay;
    [SerializeField] private float _activeTime;
    [SerializeField] Transform _positionToSpawn;
    [SerializeField] string shaderVarRef;
    [SerializeField] private float _shaderVarRate;
    [SerializeField] private float _shaderRefreshRate;
    
    

    private SkinnedMeshRenderer[] _skinnedMeshRenderers;

    IEnumerator ActivateTrail(float timeActive)
    {
        while (timeActive > 0)
        {
            timeActive -= _meshFrameRate;

            if (_skinnedMeshRenderers == null) _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            
            for(int i=0; i<_skinnedMeshRenderers.Length; i++)
            {
                GameObject gObj = new GameObject();
                gObj.transform.SetPositionAndRotation(_positionToSpawn.position, _positionToSpawn.rotation);
                
                MeshRenderer meshRenderer = gObj.AddComponent<MeshRenderer>();
                MeshFilter meshFilter = gObj.AddComponent<MeshFilter>();

                Mesh nMesh = new Mesh();
                _skinnedMeshRenderers[i].BakeMesh(nMesh);

                meshFilter.mesh = nMesh;
                meshRenderer.material = _effectMaterial;

                StartCoroutine(AnimateMaterialFloat(meshRenderer.material, 0, _shaderVarRate, _shaderRefreshRate));
                
                Destroy(gObj, _meshDestroyDelay);
            }
            
            yield return new WaitForSeconds(_meshFrameRate);
        }
    }

    public void StartTrail()
    {
        StartCoroutine(ActivateTrail(_activeTime));
    }

    IEnumerator AnimateMaterialFloat(Material mat, float goal, float rate, float refreshRate)   
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        while (valueToAnimate > goal)
        {
            valueToAnimate -= rate;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
