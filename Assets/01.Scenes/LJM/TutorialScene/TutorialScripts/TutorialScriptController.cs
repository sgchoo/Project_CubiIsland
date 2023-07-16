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
    public TMP_Text text;

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
                guideScreen.SetActive(true);
                return;
            }
            scriptIdx+=1;
            text.text = scripts[scriptIdx];
            VideoPlay();
            Debug.Log(videoSequence.Count + " " + sequence);
        }        
    }

    private void VideoPlay()
    {
        if(GetComponent<TutorialVideoController>().IsNull()) return;
        if(videoSequence.Count == sequence) 
        {
            Debug.Log("A");
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
        string name = SceneManager.GetActiveScene().name;
        switch(name)
        {
            case KeyStore.plazaScene :
                scripts = TutorialScripts.plaza01;
                scriptIdx = 0;
                text.text = scripts[scriptIdx];
                videoSequence.Add(3);
                videoSequence.Add(4);
                break;
        }
        
    }

       
}
