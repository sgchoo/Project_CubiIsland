using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public static bool isTouch = false;

    public SFXSoundManager sfxSoundManager;
    private bool isSFXPlaying = false;
    
    private void Start() 
    {
        isTouch = false;    
    }

    void Update()
    {
        touchBehaviour();   
    }

    private void touchBehaviour()
    {
        isTouching();
        if (Input.GetMouseButtonDown(0) && isSFXPlaying == false)
        {
            playTouchSound();
        }
        isSFXPlaying = false;
    }

    private void playTouchSound()
    {
        sfxSoundManager.playTouchSound();
        isSFXPlaying = true;
    }

    private void isTouching()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouch = true;
            }
            else if (touch.phase == TouchPhase.Ended && isTouch)
            {
                isTouch = false;
            }
        }
    }
}
