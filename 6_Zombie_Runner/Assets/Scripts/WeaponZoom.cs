using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 25f;
    bool isZoom = false;
    
    void Start()
    {
        fpsCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HandleZoom();
        }
    }

    private void HandleZoom()
    {
        if (isZoom)
        {
            fpsCamera.fieldOfView = zoomedOutFOV;
            isZoom = false;
        }
        else if (!isZoom)
        {
            fpsCamera.fieldOfView = zoomedInFOV;
            isZoom = true;
        }
    }
   
}
