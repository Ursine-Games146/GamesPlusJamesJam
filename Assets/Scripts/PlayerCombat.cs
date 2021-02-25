using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
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
