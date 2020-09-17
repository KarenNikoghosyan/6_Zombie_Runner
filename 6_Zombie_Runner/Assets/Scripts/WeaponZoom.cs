using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 25f;
    bool isZoom = false;

    [SerializeField] float zoomOutSensitivity = 2f;

    [SerializeField] float zoomInSensitivity = 0.5f;

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
            isZoom = false;
            fpsCamera.fieldOfView = zoomedOutFOV;
            fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        }
        else if (!isZoom)
        {
            isZoom = true;
            fpsCamera.fieldOfView = zoomedInFOV;
            fpsController.mouseLook.XSensitivity = zoomInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomInSensitivity;
        }
    }
   
}
