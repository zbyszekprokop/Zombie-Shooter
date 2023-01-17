using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]float Health = 100f;
    public void TakeDamage(float weaponDamage)
    {
        BroadcastMessage("OnDamageTaken");
        Health -= weaponDamage;
        Debug.Log("Health: " + Health);
        if(Health <= 1)
        {
            GetComponent<EnemyAI>().EnemyDeath();
        }
    }
}
