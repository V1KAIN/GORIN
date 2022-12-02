using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentSync : MonoBehaviour
{
    [SerializeField] private Material _wallMaterial;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _mask;

    public static int PosID = Shader.PropertyToID("_PlayerPosition");
    public static int SizeID = Shader.PropertyToID("_Size");

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        var dir = _mainCamera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, _mask))
        {
            _wallMaterial.SetFloat(SizeID, 1);
        }
        else
        {
            _wallMaterial.SetFloat(SizeID, 1);
        }
        
        var view = _mainCamera.WorldToViewportPoint(transform.position);
        _wallMaterial.SetVector(PosID, view);
        
        
    }
}
