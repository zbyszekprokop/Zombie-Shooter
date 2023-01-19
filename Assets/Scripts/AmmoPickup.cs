using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField]int ammoAmmount =5;
    [SerializeField]AmmoType ammoType;
    public AudioSource ammoSFX;

    void OnTriggerEnter(Collider other) 
    {
        ammoSFX.Play();
        FindObjectOfType<Ammo>().AddCurrentAmmo(ammoType, ammoAmmount);
        Destroy(gameObject, 0.4f);
    }
}
