using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle_UI : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;

    public Toggle SFXTog;
    public Toggle BGMTog;

    private Image ChangeImg;
    private Toggle tog;
    int index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SFXTog.isOn)
        {
            Settings(ref SFXTog, On);
        }
        if (!SFXTog.isOn)
        {
            Settings(ref SFXTog, Off);
        }
        if (BGMTog.isOn)
        {
            Settings(ref BGMTog, On);
        }
        if (!BGMTog.isOn)
        {
            Settings(ref BGMTog, Off);
        }
    }

    private void Settings(ref Toggle tog, Sprite img)
    {
        // toggle이 켜져있다면. == 음소거임
        // 게임오브젝트의 child (0)을 가져옴
        // 그것의 스프라이트 이미지를 바꿈
        GameObject BG = tog.transform.GetChild(0).gameObject;
        ChangeImg = BG.GetComponent<Image>();
        ChangeImg.sprite = img;


    }

}
