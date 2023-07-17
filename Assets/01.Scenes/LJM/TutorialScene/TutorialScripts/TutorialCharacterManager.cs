using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialCharacterManager : MonoBehaviour
{

    public GameObject[] guide;
    private int guideIdx = 0;

    private void Start() 
    {
        foreach(var target in guide)
        {
            target.SetActive(false);
        }
        guide[0].SetActive(true);
        guideIdx = 0;
    }

    public void OnClick()
    {
        if(TouchManager.isTouch)
        {
            if(guideIdx+1 < guide.Length)
            {
                guide[guideIdx++].SetActive(false);
                guide[guideIdx].SetActive(true);
            }
            else
            {
                foreach(var target in guide)
                {
                    target.SetActive(false);
                }
            }
        }        
    }
}

