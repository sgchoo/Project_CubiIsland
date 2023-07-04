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

    private float currentValue;
    private float targetValue;
    private int currentText;
    private float displayTime;

    public float textChangeTime;


    void Start()
    {
        gameObject.SetActive(true);

        targetValue = 3.5f;
        displayTime = 3f;
        currentValue = LoadingSlider.value;
        currentText = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ActSlider();
        ActText();
    }

    private void ActSlider()
    {
        if (TouchCheck_UI.isTouch == true || timer >= 10f)
        {
            gameObject.SetActive(false);
        }

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


     private void ActText()
    {
        if (timer % textChangeTime <= 0.01f)
        {
            texts[currentText].gameObject.SetActive(false);
            currentText = (currentText + 1) % texts.Length;
            // 1 % 3 => 1
            // 2 % 3 => 2
            // 3 % 3 => 0
            // 4 % 3 => 1
        }
        else 
        {
            texts[currentText].gameObject.SetActive(true);
        }
    }
}
