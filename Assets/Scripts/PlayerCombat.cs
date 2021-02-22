using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    public GameObject Fist;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("punch");
        }
    }

    public void DoAttack()
    {
        Fist.SetActive(true);
    }

    public void EndAttack()
    {
        Fist.SetActive(false);
    }
}
