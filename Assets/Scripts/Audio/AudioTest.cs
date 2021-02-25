using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AkSoundEngine.PostEvent("Play_EnemyHit", gameObject);
        }
    }
}
