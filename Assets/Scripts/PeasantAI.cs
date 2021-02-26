using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAI : MonoBehaviour
{
    public GameManagement manager;
    public int enemyCount;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        enemyCount = manager.enemyCount;

        if(enemyCount > 0)
        {
            anim.SetBool("scared", true);
            anim.SetBool("idle", false);
        }

        if(enemyCount == 0)
        {
            anim.SetBool("scared", false);
            anim.SetBool("idle", true);
        }
    }
}
