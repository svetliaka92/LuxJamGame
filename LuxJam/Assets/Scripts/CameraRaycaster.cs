using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    [SerializeField] private float interactRange = 2f;
    private Camera _mainCam;

    private RaycastHit? _hit;
    public RaycastHit? Hit => _hit;

    private void Awake()
    {
        _mainCam = GetComponent<Camera>();
    }

    void Update()
    {
        RaycastForTarget();
    }

    private void RaycastForTarget()
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactRange))
            _hit = hitInfo;
        else
            _hit = null;
    }
}
