using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]float Health =100f;
    public void PlayerHit(float damage)
    {
        Health -= damage;
        Debug.Log("Health: " + Health);
        if(Health <= 1)
        {
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("dead :(");
        }
    }
}
