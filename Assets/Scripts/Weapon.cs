using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]Camera FPCamera;
    [SerializeField]float range =100f;
    [SerializeField]float weaponDamage = 20f;
    [SerializeField]ParticleSystem MuzzleFlash;
    [SerializeField]GameObject HitEffect;
    [SerializeField]Ammo ammoSlot;
    GameObject parentGameObject;

    void Start() 
    {
         parentGameObject = GameObject.FindWithTag("Spawn");
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(ammoSlot.GetCurrentAmmo() >= 1)
            {
                Shoot();
            }          
        }
    }
    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo();
    }
    void PlayMuzzleFlash()
    {
        MuzzleFlash.Play();
    }
    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }
    void CreateHitEffect(RaycastHit hit)
    {
        GameObject vfx = Instantiate(HitEffect, hit.point, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
