using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField]float restoreAngle=50f;
    [SerializeField]float restoreIntensity=4f;
    public AudioSource batterySFX;

    private void OnTriggerEnter(Collider other) 
    {
        batterySFX.Play();
        other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(restoreAngle);
        other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(restoreIntensity);
        Destroy(gameObject, 0.7f);
    }
 
}
