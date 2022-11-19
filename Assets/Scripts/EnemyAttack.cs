using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]float damage = 10f;
    PlayerHealth target;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(target == null) return;
        target.PlayerHit(damage);
        Debug.Log("bang bang");
    }

}

