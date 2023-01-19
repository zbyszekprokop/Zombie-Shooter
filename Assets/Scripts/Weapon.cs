using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]Camera FPCamera;
    [SerializeField]float range =100f;
    [SerializeField]float weaponDamage = 20f;
    [SerializeField]ParticleSystem MuzzleFlash;
    [SerializeField]GameObject HitEffect;
    [SerializeField]Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField]float timeBetweenShots =0.5f;
    [SerializeField]TextMeshProUGUI ammoText;
    GameObject parentGameObject;
    

    bool canShoot=true;
    private void OnEnable() 
    {
        canShoot=true;
    }

    void Start() 
    {
         parentGameObject = GameObject.FindWithTag("Spawn");
    }
    void Update()
    {
        DisplayAmmo();
        if(Input.GetButtonDown("Fire1")&& canShoot==true)
        {
                StartCoroutine(Shoot());
        }
    }
    void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }
    IEnumerator Shoot()
    {
        canShoot=false;
        if(ammoSlot.GetCurrentAmmo(ammoType) >=1)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot=true;
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
