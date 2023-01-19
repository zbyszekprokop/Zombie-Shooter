using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField]float restoreAngle=50f;
    [SerializeField]float restoreIntensity=4f;

    private void OnTriggerEnter(Collider other) 
    {
        other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(restoreAngle);
        other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(restoreIntensity);
        Destroy(gameObject);
    }
 
}
