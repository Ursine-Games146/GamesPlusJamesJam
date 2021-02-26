using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAudio : MonoBehaviour
{
    public GameObject mainCamera;
    public void PlayAudio()
    {
        if(mainCamera)
        {
            AkSoundEngine.PostEvent("Play_Footsteps", mainCamera);
        }
    }
}
