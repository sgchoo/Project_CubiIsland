using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip touchSound;
    public AudioClip[] landingSounds;
    public AudioClip rollSound;
    

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    public void playTouchSound()
    {
        audioSource.PlayOneShot(touchSound);
    }

    public void PlayLandingSound()
    {
        if(GameData.Instance.currentWorld.name == "Map01_Forest")
        {
            audioSource.PlayOneShot(landingSounds[0]);
        }
        else if(GameData.Instance.currentWorld.name == "Map02_Snow")
        {
            audioSource.PlayOneShot(landingSounds[1]);
        }
    }

    public void PlayRollSound()
    {
        audioSource.PlayOneShot(rollSound);
    }
}
