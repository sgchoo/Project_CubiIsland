using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager_LYN : MonoBehaviour
{
    [Header("옵션창 패널")]
    public GameObject OptionPanel;

    public Toggle SFXTog, BGMTog;

    public Slider SFXSlider, BGMSlider;

    private static OptionManager_LYN instance = null;
    
    private bool isSFXPlaying = false;
    private float SFXVol, BGMVol;

    [Header("효과음 파일")]
    public AudioClip SFXTouchClip;

    private AudioSource SFXTouch;
    
    //
    private static float SFXSliderVol = 0;
    private static float BGMSliderVol = 0;
    private static bool SFXMute = false;
    private static bool BGMMute = false;
    
    public static float GetSFXSliderVol() { return SFXSliderVol; }
    public static float GetBGMSliderVol() { return BGMSliderVol; }
    public static bool GetSFXMute() { return SFXMute; }
    public static bool GetBGMMute() { return BGMMute; }
    
    private const string sfxMuteKey = "SFXMute";
    private const string bgmMuteKey = "BGMMute";
    private const string sfxVolumeKey = "SFXVolume";
    private const string bgmVolumeKey = "BGMVolume";


    // 다른 스크립트에서 참조할 수 있도록 프로퍼티 설정, instance 반환
    public static OptionManager_LYN Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SFXTouch = GetComponent<AudioSource>();
    }

    public void OpenOption()
    {
        // 옵션창 켜기
        OptionPanel.SetActive(true);
    }

    public void CloseOption()
    {
        // 옵션창 끄기
        OptionPanel.SetActive(false);
    }


    // public void SFXOnOff()
    // {
    //     if (SFXTog.isOn)
    //     {
    //         // SFX가 켜져있는 경우. 터치 및 버튼의 효과음이 나야 함.
    //         // 터치 시 효과음 구현
    //         if (Input.GetMouseButtonDown(0) && isSFXPlaying == false)
    //         {
    //             SFXTouch.PlayOneShot(SFXTouchClip);
    //             isSFXPlaying = true;
    //         }
    //         isSFXPlaying = false;
    //     }
    // }


    // 볼륨 설정(슬라이더) ----
    public void SetVolume(Slider slider)
    {
        if(slider.name == "SFXSlider")       
        {
            SFXSliderVol = slider.value;
        }
        else if (slider.name == "BGMSlider") 
        {
            BGMSliderVol = slider.value;
        }
        if(!isSFXPlaying)
        {
            isSFXPlaying = true;
            SFXTouch.PlayOneShot(SFXTouchClip);
            StartCoroutine(WaitForClipEnd(SFXTouchClip.length));
        }
    }

    // 볼륨 설정(토글) ----
    public void SetVolume(Toggle toggle)
    {
        if(toggle.name == "SFXToggle")       
        {
            SFXMute = toggle.isOn;
        }
        else if (toggle.name == "BGMToggle")
        {
            BGMMute = toggle.isOn;
        } 

        SFXTouch.PlayOneShot(SFXTouchClip);
 
    }

    private IEnumerator WaitForClipEnd(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        isSFXPlaying = false;
    }

    // 볼륨 가져오기(SFX)
    public float GetSFXVolume()
    {
        return GetVolume(SFXTog, SFXSlider);
    }

    // 볼륨 가져오기(BGM)
    public float GetBGMVolume()
    {
        return GetVolume(BGMTog, BGMSlider);
    }

    // 볼륨 가져오기 메인 기능
    public float GetVolume(Toggle tog, Slider slider)
    {
        float volume = 0f;

        if (!tog.isOn) volume = 0f;
        else volume = slider.value;

        return volume;
    }

    // public void SFXVolume()
    // {
    //     float SFXVolume = SFXSlider.value;
    //     AudioListener.volume = SFXVolume;
    // }

    // 설정한 볼륨 저장
    private void SaveVolume()
    {
        PlayerPrefs.SetInt(sfxMuteKey, SFXMute ? 1 : 0);
        PlayerPrefs.SetInt(bgmMuteKey, BGMMute ? 1 : 0);
        PlayerPrefs.SetFloat(sfxVolumeKey, SFXSliderVol);
        PlayerPrefs.SetFloat(bgmVolumeKey, BGMSliderVol);
        PlayerPrefs.Save();
    }

    // 설정했던 볼륨 가져오기
    private void LoadVolume()
    {
        if(PlayerPrefs.HasKey(sfxMuteKey)) SFXMute = PlayerPrefs.GetInt(sfxMuteKey) == 1 ? true : false;
        if(PlayerPrefs.HasKey(bgmMuteKey)) BGMMute = PlayerPrefs.GetInt(bgmMuteKey) == 1 ? true : false;
        if(PlayerPrefs.HasKey(sfxVolumeKey)) SFXSliderVol = PlayerPrefs.GetFloat(sfxVolumeKey);
        if(PlayerPrefs.HasKey(bgmVolumeKey)) BGMSliderVol = PlayerPrefs.GetFloat(bgmVolumeKey);

        SFXTog.isOn = SFXMute;
        BGMTog.isOn = BGMMute;
        SFXSlider.value = SFXSliderVol;
        BGMSlider.value = BGMSliderVol;
    }

    // Start is called before the first frame update
    void Start()
    {
        Settings();
        LoadVolume();
    }

    // Option 패널이 활성화되면 리셋 후 볼륨 데이터 불러오기
    private void OnEnable() 
    {
        Settings();
        LoadVolume();
    }

    // Option 패널이 비활성화되면 볼륨 데이터 저장하기
    private void OnDisable() 
    {
        SaveVolume();
    }

    // 볼륨 데이터 초기화
    private void Settings()
    {
        SFXMute = SFXTog.isOn; 
        BGMMute = BGMTog.isOn; 

        SFXSliderVol = SFXSlider.value;
        BGMSliderVol = BGMSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //SFXOnOff();
        // Debug.Log("SFX Mute : " + SFXMute + " || value : " + SFXSliderVol +
        //           "\nBGM Mute : " + BGMMute + " || value : " + BGMSliderVol);
    }

    public void GoLink()
    {
        // ImageDownloadManager downloadManager = new ImageDownloadManager();
        // downloadManager.DownloadImage();
        new ImageDownloadManager().DownloadObject();
    }
}
