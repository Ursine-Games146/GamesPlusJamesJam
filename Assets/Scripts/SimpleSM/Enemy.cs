using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private bool isDead = false;
    public float enemyHP = 6;
    Animator anim;
    NavMeshAgent agent;
    Transform player;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        agent.SetDestination(player.position);
    }

    
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(isDead)
        {
            gameObject.SetActive(false);
            return;
        }

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
        }

        anim.SetFloat("speed", agent.velocity.magnitude);

        if(enemyHP <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("die");
        }
    }

    public void StartAttack()
    {
        if(!isDead)
        {
            StartCoroutine(AttackDelay());
        }
        
    }

    public IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(1.5f);
        StartAttack();
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("FistDamage") && !isDead)
        {
            AkSoundEngine.PostEvent("Play_EnemyHit", gameObject);
            anim.SetTrigger("hurt");
            enemyHP--;
        }
    }

}
