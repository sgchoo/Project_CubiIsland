using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScriptController : MonoBehaviour
{
    public static int scriptIdx = 0;

    public Connector connector;
    private TMP_Text text;

    public List<string> scripts;

    public void OnClick()
    {
        if(TouchManager.isTouch)
        {
            if(scriptIdx+1 == scripts.Count)
            {
                return;
            }
            scriptIdx+=1;
            text.text = scripts[scriptIdx];
        }        
    }

    private void Start() 
    {
        text = connector.text;

        string name = SceneManager.GetActiveScene().name;
        switch(name)
        {
            case KeyStore.tutorialPlaza :
                scripts = TutorialScripts.plaza01;
                scriptIdx = 0;
                text.text = scripts[scriptIdx];
                break;
        }
        
    }

       
}
