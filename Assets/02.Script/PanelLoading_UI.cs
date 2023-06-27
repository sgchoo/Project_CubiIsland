using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelLoading_UI : MonoBehaviour
{
    private bool isTouch;


    public GameObject TouchMotion;
    float timer = 0f;

    void Start()
    {
        Debug.Log(SceneCheck_UI.SceneLoad);
        gameObject.SetActive(true);
        isTouch = false;

    }

    // Update is called once per frame
    void Update()
    {
        ActTouch();
        timer += Time.deltaTime;
    }
    
    public void ActTouch()
    {
        if (timer >= 3f)
        {
            TouchMotion.SetActive(true);
            if(TouchCheck_UI.touchStarted == true)
            {
                gameObject.SetActive(false);
            }
        }
        
    }


}
