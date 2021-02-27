using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMainMusic : MonoBehaviour
{
    static bool isPlaying;
    void Start()
    {
        if(!isPlaying)
        {
            AkSoundEngine.PostEvent("Play_MainMusic", gameObject);
            isPlaying = true;
        }
    }
}
