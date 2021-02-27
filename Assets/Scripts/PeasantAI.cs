using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeasantAI : MonoBehaviour
{
    public GameManagement manager;
    public int enemyCount;
    public int enemyKilled;
    Animator anim;
    public GameObject dialogue;
    public Text text;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        enemyCount = manager.enemyCount;
        enemyKilled = manager.enemyKilled;
        if(enemyCount > 0)
        {
            anim.SetBool("scared", true);
            anim.SetBool("idle", false);
            text.text = "Help me! Help!";
        }

        if(enemyCount == 0)
        {
            anim.SetBool("scared", false);
            anim.SetBool("idle", true);

            if(enemyKilled <=3)
            {
                text.text = "What do you want? Go kill some goblins";
            }

            if(enemyKilled ==4)
            {
                text.text = "I guess you're not bad";
            }

            if(enemyKilled >= 6)
            {
                text.text = "Wow! You're the best! Thank you!";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(false);
        }
    }
}
