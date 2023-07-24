using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenMode_UI : MonoBehaviour
{
    bool isLandscape;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "01.TitleScene")
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // 가로가 더 길 경우, 가로모드
        if (Screen.width > Screen.height)
        {
            isLandscape = true;
        }
        else
        {
            isLandscape = false;
        }
    }

    public void SetScreenMode()
    {
        // 가로 -> 세로
        if (isLandscape)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        //세로 -> 가로
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }

    
}

