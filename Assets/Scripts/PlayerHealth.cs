using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]float Health =100f;
    [SerializeField]TextMeshProUGUI healthDisplay;
    DamageDisplay damageDisplay;
    void Start() 
    {
        damageDisplay = GetComponent<DamageDisplay>();
    }
    public void PlayerHit(float damage)
    {
        damageDisplay.DisplayDamage();
        Health -= damage;
        healthDisplay.text = Health.ToString();
        if(Health <= 1)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
