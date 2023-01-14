using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [SerializeField]Camera fpsCamera;
    [SerializeField]RigidbodyFirstPersonController firstPersonController;
    [SerializeField]float zoomFieldOfView = 30f;
    [SerializeField]float outZoomFOV =60f;
    [SerializeField]float zoomInSensitivity = .5f;
    [SerializeField]float zoomOutSensitivity = 2f;

    bool isZoom = false;
    private void OnDisable() 
    {
        ZoomOut();
    }
    void Update()
    {
        ZoomSequence();
    }

    void ZoomSequence()
    {
        if(isZoom == false)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                ZoomIn();
            }
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        Camera.main.fieldOfView = outZoomFOV;
        firstPersonController.mouseLook.XSensitivity = zoomOutSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomOutSensitivity;
        isZoom = false;
    }

    void ZoomIn()
    {
        Camera.main.fieldOfView = zoomFieldOfView;
        firstPersonController.mouseLook.XSensitivity = zoomInSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomInSensitivity;
        isZoom = true;
    }
}
