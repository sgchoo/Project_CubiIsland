using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound
{
    public bool mute;
    public float volume;

    public void SetSound(string muteKey, string volumeKey)
    {
        PlayerPrefs.SetInt(muteKey, this.mute ? 1 : 0);
        PlayerPrefs.SetFloat(volumeKey, this.volume);
        PlayerPrefs.Save();
    }


    public void LoadSound(string muteKey, string volumeKey)
    {
        if(PlayerPrefs.HasKey(muteKey)) 
        {
            this.mute = PlayerPrefs.GetInt(muteKey) == 1 ? true : false;
        }
        else 
        {
            this.mute = false;
        }

        if(PlayerPrefs.HasKey(volumeKey)) 
        {
            this.volume = PlayerPrefs.GetFloat(volumeKey);
        }
        else
        {
            this.volume = 100;
        }
    }
    
}