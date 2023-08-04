using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    private static OptionManager instance = null;
    public static OptionManager Instance
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
        }    
    }

    public Toggle SFXTog, BGMTog;

    public Slider SFXSlider, BGMSlider;

    public void SetSFXVolume()
    {
        GameData.Instance.sfx.volume = SFXSlider.value;
        GameData.Instance.SetAudioVolume();
    }
    
    public void SetBGMVolume()
    {
        GameData.Instance.bgm.volume = BGMSlider.value;
        GameData.Instance.SetAudioVolume();
    }

    public void SetSFXMute()
    {
        GameData.Instance.sfx.mute = SFXTog.isOn;
        GameData.Instance.SetAudioVolume();
    }

    public void SetBGMMute()
    {
        GameData.Instance.bgm.mute = BGMTog.isOn;
        GameData.Instance.SetAudioVolume();
    }

    public void GoLink()
    {
        // ImageDownloadManager downloadManager = new ImageDownloadManager();
        // downloadManager.DownloadImage();
        new ImageDownloadManager().DownloadObject();
    }

    public void SettingSounds()
    {
        SFXTog.isOn = GameData.Instance.sfx.mute;
        BGMTog.isOn = GameData.Instance.bgm.mute;

        SFXSlider.value = GameData.Instance.sfx.volume;
        BGMSlider.value = GameData.Instance.bgm.volume;
    }

    private void OnEnable() 
    {
        SettingSounds();
    }

    private void OnDisable() 
    {
        Debug.Log("저장");  
        GameData.Instance.sfx.SetSound(KeyStore.sfxMuteKey, KeyStore.sfxVolumeKey);
        GameData.Instance.bgm.SetSound(KeyStore.bgmMuteKey, KeyStore.bgmVolumeKey);
        GameData.Instance.SetAudioVolume();
    }
}
