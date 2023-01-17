using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField]float chaseRange =5f;
    [SerializeField]float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        AttackingSequence();
    }

    void AttackingSequence()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            
        }
    }
    void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackPlayer()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }
    
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*turnSpeed);
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);   
    }
    public void EnemyDeath()
    {
        GetComponent<Animator>().SetTrigger("death");
        GetComponent<EnemyAI>().enabled=false;
        GetComponent<EnemyAttack>().enabled=false;
        GetComponent<CapsuleCollider>().enabled=false;
        navMeshAgent.enabled=false;
    }
}
