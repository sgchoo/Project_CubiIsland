using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;

public class PanelLoading_UI : MonoBehaviour
{
    // 7-2 LoadScene 인식 타겟 이미지 아이콘
    [Header("맵 아이콘, 직접연결")]
    public Sprite[] MapIcons;

    // 7-2 LoadScene 인식 타겟 월드 타이틀
    [Header("맵 이름, 직접연결")]
    public TextMeshProUGUI MapTitle;

    // AR On/Off를 위한 변수
    public static bool ActAR = false;

    // 터치 모션 활성화
    public GameObject TouchMotion;

    // 타이머 설정
    private float timer = 0f;

    // 알파값 변하는 속도
    private float fadeDuration;

    // 알파 값을 변화시켜 fadeout시키기위한 변수
    private CanvasGroup DisappearObject;

    // 이미지 인식 씬에서 재탕
    private Image MapIcon;

    private bool fadeOut = false;

    public GameObject imageIcon;

    
    void Start()
    {
        
        fadeDuration = 1f;
        DisappearObject = GetComponent<CanvasGroup>();
        ActAR = false;

        if (SceneManager.GetActiveScene().name == KeyStore.loadScene)
        {
            Debug.Log("PanelLoading_UI::Complete");
            // 교체할 맵 아이콘 받아오기
            MapIcon = imageIcon.GetComponent<Image>();
            SetMapIcon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ActTouch();
    }


    private void ActTouch()
    {
        if (TouchManager.isTouch || timer >= 3f)
        {
            ScanImage_UI.ScanimageAct = true;
            ActAR = true;
            StartCoroutine(FadeOutIcon());
        }
        
    }
    private IEnumerator FadeOutIcon()
    {
        float elapsedTime = 0f;
        float startAlpha = DisappearObject.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            // 패널 창의 투명도를 서서히 감소
            DisappearObject.alpha = Mathf.Lerp(startAlpha, 0f, t);

            yield return null;
        }
        // Transition 효과 종료 후, 패널 창 완전히 비활성화
        
        gameObject.SetActive(false);
        
    }
    
    private void UpdateMapInfo(Sprite sprite, string text)
    {
        MapIcon.sprite = sprite;
        MapTitle.text = text;
    }

    private void SetMapIcon()
    {
        Debug.Log("PanelLoading_UI::"+GameData.Instance.currentWorld.name);
        switch(GameData.Instance.currentWorld.name)
        {
            case "Map01_Forest" : UpdateMapInfo(MapIcons[0], "FOREST"); break;
            case "Map02_Snow"   : UpdateMapInfo(MapIcons[1], "SNOW");   break;
            case "Map03_Desert" : UpdateMapInfo(MapIcons[2], "DESERT"); break;
        }
        // if (GameData.Instance.currentWorld.name == "Map01_Forest")
        // {
        //     // 선택한 맵의 아이콘 출력
        //     MapIcon.sprite = MapIcons[0];

        //     // 선택한 맵의 이름 출력
        //     MapTitle.text = "FOREST";
        // }

        // if (GameData.Instance.currentWorld.name == "Map02_Snow")
        // {
        //     // 선택한 맵의 아이콘 출력
        //     MapIcon.sprite = MapIcons[1];

        //     // 선택한 맵의 이름 출력
        //     MapTitle.text = "SNOW";
        // }

        // if (GameData.Instance.currentWorld.name == "Map03_Desert")
        // {
        //     // 선택한 맵의 아이콘 출력
        //     MapIcon.sprite = MapIcons[2];

        //     // 선택한 맵의 이름 출력
        //     MapTitle.text = "DESERT";
        // }
    }

}
