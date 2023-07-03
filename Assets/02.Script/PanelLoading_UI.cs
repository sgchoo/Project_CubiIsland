using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelLoading_UI : MonoBehaviour
{

    public GameObject TouchMotion;
    float timer = 0f;

    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        ActTouch();
        timer += Time.deltaTime;
    }
    
    public void ActTouch()
    {
        // 씬 로드 3초 후
        if (timer >= 3f)
        {
            // 터치 모션 켜짐
            TouchMotion.SetActive(true);
            // 터치가 되고 있다면
            if(TouchCheck_UI.isTouch == true)
            {
                gameObject.SetActive(false);
            }
        }
    }


}
