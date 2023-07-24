using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GameLoading_UI : MonoBehaviour
{
    [Header("로딩 슬라이더")]
    public Slider LoadingSlider;

    [Header("순환할 텍스트, 직접 연결")]
    public TextMeshProUGUI[] texts;

    private float timer = 0f;
    private float textTimer = 0f;

    private float currentValue;
    private float targetValue;
    private int currentText;

    // 하단 텍스트가 변경되는 시간(기본 3f)
    public float textChangeTime;

    public static bool LoadingPanelIsAct;


    void Start()
    {
        gameObject.SetActive(true);

        targetValue = 3f;
        currentValue = LoadingSlider.value;
        currentText = 0;
        timer = 0f;
        textTimer = 0f;
        LoadingPanelIsAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textTimer += Time.deltaTime;
        //Debug.Log("GameLoading_UI::Touch - " + TouchManager.isTouch);
        // 터치했거나, 로딩시간이 10초가 지났을 경우 패널 비활성화
        // if (Input.GetMouseButtonDown(0) ||timer >= 9f)
        if(timer >= 9f)
        {
            GameLoadingManager.isDetectPanel = true;
            gameObject.SetActive(false);
            LoadingPanelIsAct = false;
            //Debug.Log("GameLoading_UI::Touch - " + GameLoadingManager.isDetectPanel);
            return;
        }
        ActSlider();
        ActText();
    }

    private void ActSlider()
    {
        //Debug.Log("GameLoading_UI::ActSlider");
        
        // 슬라이더 채우기
        // 만약 3초라면, 1초 기다렸다가 움직이기
        if (timer <= targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, 1f * Time.deltaTime);
            LoadingSlider.value = currentValue;
        }
        if (timer > 6f)
        {
            currentValue = Mathf.MoveTowards(currentValue, LoadingSlider.maxValue, 1f * Time.deltaTime);
            LoadingSlider.value = currentValue;
        }
    }
    
    // 텍스트 출력 반복 돌리기
     private void ActText()
    {
        if (textTimer >= textChangeTime)
        {
            textTimer = 0f;
            Debug.Log("GameLoading_UI::ActText1");
            texts[currentText].gameObject.SetActive(false);
            currentText = (currentText + 1) % texts.Length;
            //currentText += 1;
            //if(currentText >= texts.Length) currentText = 0;

            // 1 % 3 => 1
            // 2 % 3 => 2
            // 3 % 3 => 0
            // 4 % 3 => 1
        }
        else 
        {
            Debug.Log("GameLoading_UI::ActText2");
            texts[currentText].gameObject.SetActive(true);
        }
    }
}
