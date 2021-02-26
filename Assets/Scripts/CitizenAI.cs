using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CitizenAI : MonoBehaviour
{

    public GameManagement manager;
    Animator anim;
    public bool needsHelp;
    public bool isHappy, isUnhappy;
    public int enemyCount;
    public GameObject helpBox;
    GameObject[] enemy;
    List<GameObject> enemies;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemies = new List<GameObject>();
    }



    void Update()
    {
        enemyCount = manager.enemyCount;

        if (enemyCount == 0)
        {
            anim.SetBool("Help", true);
        }

        if(enemyCount > 0)
        {
            anim.SetBool("Help", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            helpBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            helpBox.SetActive(false);
        }
    }
}
    
