using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float intensityAmount = 20f;
    [SerializeField] float restoreAngle = 75f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityAmount);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            Destroy(gameObject);
        }    
    }
}
