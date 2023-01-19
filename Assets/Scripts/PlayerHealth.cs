using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]float Health =100f;
    DamageDisplay damageDisplay;
    void Start() 
    {
        damageDisplay = GetComponent<DamageDisplay>();
    }
    public void PlayerHit(float damage)
    {
        damageDisplay.DisplayDamage();
        Health -= damage;
        Debug.Log("Health: " + Health);
        if(Health <= 1)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("dead :(");
        }
    }
}
