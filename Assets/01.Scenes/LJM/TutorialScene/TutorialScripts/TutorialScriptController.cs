using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScriptController : MonoBehaviour
{
    public int scriptIdx = 0;

    public GameObject infoParent;
    public GameObject background;
    public GameObject guideScreen;
    public GameObject selectCharGuideScreen;
    public GameObject selectWorldGuideScreen;
    public TMP_Text text;

    public static int tutorialCount = 0;

    public List<string> scripts;
    private List<int> videoSequence;
    private int sequence = 0;

    public void OnClick()
    {
        if(TouchManager.isTouch)
        {
            if(scriptIdx+1 == scripts.Count)
            {
                infoParent.SetActive(false);
                background.SetActive(false);

                if(tutorialCount == 0)
                {
                    selectCharGuideScreen.SetActive(true);
                    tutorialCount = 1;
                }
                else if(tutorialCount == 1)
                {
                    selectWorldGuideScreen.SetActive(true);
                    tutorialCount = 2;
                }
                else if(tutorialCount == 2)
                {
                    tutorialCount = 0;
                    GameData.Instance.tutorial = false;
                    GameData.Instance.tutorialPlaza = false;
                    PlayerPrefs.SetInt(KeyStore.tutorialKey, 1);
                    PlayerPrefs.SetInt(KeyStore.TUTORIAL_PLAZA_KEY, 1);
                    PlayerPrefs.Save();
                    guideScreen.SetActive(true);

                }
                return;
            }
            scriptIdx+=1;
            text.text = scripts[scriptIdx];
            // if(scriptIdx+1 == scripts.Count)
            // {
            //     infoParent.SetActive(false);
            //     background.SetActive(false);
            //     guideScreen.SetActive(true);
            //     return;
            // }
            // scriptIdx+=1;
            // text.text = scripts[scriptIdx];
            // VideoPlay();
            // Debug.Log(videoSequence.Count + " " + sequence);
        }        
    }

    private void VideoPlay()
    {
        if(GetComponent<TutorialVideoController>().IsNull()) return;
        if(videoSequence.Count == sequence) 
        {
            GetComponent<TutorialVideoController>().Close();
            return;
        }
        if(videoSequence[sequence] == scriptIdx)
        {
            GetComponent<TutorialVideoController>().Open();
            GetComponent<TutorialVideoController>().Play();
            sequence++;
        }
    }

    private void Start() 
    {
        sequence = 0;
        videoSequence = new List<int>();
        //text = connector.text;
        infoParent.SetActive(true);
        background.SetActive(true);
        guideScreen.SetActive(false);
        selectCharGuideScreen.SetActive(false);
        selectWorldGuideScreen.SetActive(false);
        if(tutorialCount == 0)
        {
            scripts = TutorialScripts.plaza01;
            scriptIdx = 0;
            text.text = scripts[scriptIdx];
        }
        else if(tutorialCount == 1)
        {
            scripts = TutorialScripts.plaza02;
            scriptIdx = 0;
            text.text = scripts[scriptIdx];
        }
        else if(tutorialCount == 2)
        {
            Debug.Log("AAAA");
            scripts = TutorialScripts.plaza03;
            scriptIdx = 0;
            text.text = scripts[scriptIdx];
        }
                
                
        
    }

       
}
