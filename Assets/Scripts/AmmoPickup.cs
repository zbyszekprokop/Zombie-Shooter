using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField]int ammoAmmount =5;
    [SerializeField]AmmoType ammoType;

    void OnTriggerEnter(Collider other) 
    {
        FindObjectOfType<Ammo>().AddCurrentAmmo(ammoType, ammoAmmount);
        Destroy(gameObject);
    }
}
