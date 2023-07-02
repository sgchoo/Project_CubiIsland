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

    public void SFXOnOff()
    {
        if (SFXTog.isOn)
        {
            // SFX가 켜져있는 경우. 터치 및 버튼의 효과음이 나야 함.
            // 터치 시 효과음 구현
            if (Input.GetMouseButtonDown(0) && isSFXPlaying == false)
            {
                SFXTouch.PlayOneShot(SFXTouchClip);
                isSFXPlaying = true;
            }
            isSFXPlaying = false;
        }
    }

    public void SFXVolume()
    {
        float SFXVolume = SFXSlider.value;
        AudioListener.volume = SFXVolume;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SFXOnOff();
    }
}
