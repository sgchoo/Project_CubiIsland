using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortalDetectTextBehaviour : MonoBehaviour
{
    public static int mode = 0;
    public TMP_Text infoText;

    public Button createBtn;
    public GameObject createPanel;

    public readonly List<string> waitText = new List<string>
    {
        "바닥을 인식 중입니다.",
        "바닥을 인식 중입니다 . . ",
        "바닥을 인식 중입니다 . . ."
    };

    private int waitLength;
    private int waitIdx;
    private bool waitFlag;
    private bool textSetFlag;
    // public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        waitLength = waitText.Count;
        createBtn.interactable = false;
        createPanel.SetActive(false);
        waitFlag = true;
        textSetFlag = true;
        waitIdx = 0;
        timer = 0f;
        waitFlag = false;
    }

    float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        switch(mode)
        {
            case 0 :
                if(!waitFlag)
                {
                    createBtn.interactable = false;
                    createPanel.SetActive(false);
                    waitFlag = true;
                    textSetFlag = true;
                }
                
                if(timer < 0.8f)
                {
                    timer += Time.deltaTime;
                    return;
                }
                timer = 0f;
                infoText.text = waitText[waitIdx++];
                if(waitIdx >= waitLength) waitIdx = 0;
                break;
            case 1 : 

                if(textSetFlag)
                {
                    infoText.text = "바닥이 인식되었어요!\n아일랜드 생성 버튼을 눌러주세요!";
                    createBtn.interactable = true;
                    createPanel.SetActive(true);
                    textSetFlag = false;
                    waitFlag = false;
                }
                
                break;
        }
    }


}
