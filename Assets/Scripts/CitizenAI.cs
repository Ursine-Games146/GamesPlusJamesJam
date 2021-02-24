﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenAI : MonoBehaviour
{

    Animator anim;
    public bool needsHelp;
    public bool isHappy, isUnhappy;
    public int enemyCount;
    GameObject[] enemy;
    List<GameObject> enemies;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemies = new List<GameObject>();
    }

    

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(enemyCount == 0)
        {
            anim.SetBool("Help", true);
        }
    }
}