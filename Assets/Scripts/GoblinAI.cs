using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
using UnityEngine.AI;

public class GoblinAI : MonoBehaviour
{
    Animator anim;
    public Rigidbody rb;
    NavMeshAgent agent;
    private GameObject Player;
    private Transform target;
    private bool attack = false;
    public bool dead = false;
    public float lookRadius = 10f;
    private float attackDelay, lastAttack;
    GameManagement Manager;
    Collider[] ragdoll;
    public List<Collider> colliders { get; private set; }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Manager = GameObject.FindWithTag("GameManager").GetComponent<GameManagement>();
        target = Player.transform;
        lastAttack -= Time.time;
        ragdoll = GetComponentsInChildren<Collider>();
        colliders = new List<Collider>(ragdoll);
        
        
        
    }

    
    void Update()
    {

        

        float distance = Vector3.Distance(target.position, transform.position);

        if(agent.isStopped == true || dead == true)
        {
            return;
        }
        else if(!dead && agent.isStopped == false)
        {
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);

            }

            if (distance > lookRadius)
            {
                agent.SetDestination(transform.position);
            }

            if (distance <= lookRadius && distance > agent.stoppingDistance)
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

            if (!attack)
            {
                StopCoroutine(AttackPlayer());
            }
        }

        
    }

    private void LateUpdate()
    {
        if (attack && lastAttack <= 0f)
        {
            lastAttack -= Time.time;
            StartCoroutine(AttackPlayer());
        }
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }

    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(5);
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(2);
        StopCoroutine(AttackPlayer());
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("FistDamage"))
        {
            Manager.enemyCount --;
            Manager.enemyKilled++;
            AkSoundEngine.PostEvent("Play_EnemyHit", gameObject);
            dead = true;
            agent.isStopped = true;
            StopCoroutine(AttackPlayer());
            anim.SetTrigger("Die");
            Destroy(gameObject, 6);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FistDamage"))
        {
            agent.isStopped = true;
            anim.enabled = false;

            rb.AddExplosionForce(Manager.punchBackForce, transform.position + (Vector3.forward/2), 1, 0, ForceMode.Impulse);
            Destroy(this.gameObject, 5);
        }
    }
    */

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
