using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
        public AudioSource audioSource;
        public AudioClip shootSFX;
    }
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    public void AddCurrentAmmo(AmmoType ammoType, int ammoAmmount)
    {
        GetAmmoSlot(ammoType).ammoAmount+= ammoAmmount;
    }
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
        GetAmmoSlot(ammoType).audioSource.PlayOneShot(GetAmmoSlot(ammoType).shootSFX);
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType==ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
