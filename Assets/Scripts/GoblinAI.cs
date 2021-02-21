using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
using UnityEngine.AI;

public class GoblinAI : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    NavMeshAgent agent;
    private GameObject Player;
    private Transform target;
    private bool attack = false;
    public float lookRadius = 10f;
    private float attackDelay, lastAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.transform;
        lastAttack -= Time.time;
    }

    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
        }

        if(distance <= lookRadius && distance > agent.stoppingDistance)
        {
            anim.SetBool("moving", true);
            attack = false;
        }

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            anim.SetBool("moving", false);
            attack = true;

        }

        if(attack && lastAttack <= 0f)
        {
            lastAttack -= Time.time;
            StartCoroutine(AttackPlayer());
        }
        else if(!attack)
        {
            StopAllCoroutines();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(3);
        anim.SetTrigger("attack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
