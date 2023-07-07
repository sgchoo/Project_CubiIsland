using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip touchSound;
    

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    public void playTouchSound()
    {
        audioSource.PlayOneShot(touchSound);
    }
}
