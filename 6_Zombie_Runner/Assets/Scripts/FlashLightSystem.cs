using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.5f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 30f;
    
    Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.intensity = intensityAmount;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime; 
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) { return; }
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
}
