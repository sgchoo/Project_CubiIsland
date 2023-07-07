using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance = null;
    public static GameData Instance
    {
        get
        {
            if (null == instance) { return null; }
            return instance;
        }
    }

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else 
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable() 
    {
        
    }

    // 지정했던 캐릭터와 월드맵을 저장해둘 변수
    public GameObject currentCharacter;
    public GameObject currentWorld;

    // sfx, bgm을 저장해둘 변수
    public Sound sfx;
    public Sound bgm;

    public AudioSource bgmAudio;
    public AudioSource sfxAudio;

    
    private void Start() 
    {
        sfx = new Sound();
        bgm = new Sound();
        SetSound();
    }

    private void SetSound()
    {
        sfx.LoadSound(KeyStore.sfxMuteKey, KeyStore.sfxVolumeKey);
        bgm.LoadSound(KeyStore.bgmMuteKey, KeyStore.bgmVolumeKey);

        SetAudioVolume();
    }

    public void SetAudioVolume()
    {
        bgmAudio.volume = bgm.mute ? 0 : bgm.volume / 100f;
        sfxAudio.volume = sfx.mute ? 0 : sfx.volume / 100f;
    }
    

}
