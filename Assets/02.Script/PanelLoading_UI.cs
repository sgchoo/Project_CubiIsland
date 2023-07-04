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
    [Header("맵 아이콘, 직접연결")]
    public Sprite[] MapIcons;

    [Header("맵 이름, 직접연결")]
    public TextMeshProUGUI MapTitle;

    public static bool ActAR;

    // 터치 모션 활성화
    public GameObject TouchMotion;

    // 타이머 설정
    private float timer = 0f;

    // 알파값 변하는 속도
    private float fadeDuration;

    private CanvasGroup DisappearObject;
    private Image MapIcon;

    void Start()
    {
        fadeDuration = 1f;
        DisappearObject = GetComponent<CanvasGroup>();
        ActAR = false;

        // 현재씬 이름 가져오기
        if (SceneManager.GetActiveScene().name == "08.FindKeyScene")
        {
            // 교체할 맵 아이콘 받아오기
            MapIcon = GameObject.Find("ImageIcon").GetComponent<Image>();
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
        // 터치모션 2초 뒤 켜기
        if (timer >= 2f)
        {
            TouchMotion.SetActive(true);
            // 터치하면
            if (TouchCheck_UI.isTouch == true)
            {
                StartCoroutine(FadeOutIcon());
            }
        }
        // 터치하면 이미지 서서히 사라지고 AR카메라 활성화 하기
    }
    private IEnumerator FadeOutIcon()
    {
        float elapsedTime = 0f;
        float startAlpha = DisappearObject.alpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            // 패널 창의 투명도를 서서히 감소시킵니다.
            DisappearObject.alpha = Mathf.Lerp(startAlpha, 0f, t);

            yield return null;
        }
        
        
        // Transition 효과 종료 후, 패널 창 완전히 비활성화
        gameObject.SetActive(false);
        ActAR = true;
    }
    

    private void SetMapIcon()
    {
        if (UIController2_UI.FinalMap.name == "Map01_Forest")
        {
            // 선택한 맵의 아이콘 출력
            MapIcon.sprite = MapIcons[0];

            // 선택한 맵의 이름 출력
            MapTitle.text = "FOREST";
        }

        if (UIController2_UI.FinalMap.name == "Map02_Snow")
        {
            // 선택한 맵의 아이콘 출력
            MapIcon.sprite = MapIcons[1];

            // 선택한 맵의 이름 출력
            MapTitle.text = "SNOW";
        }

        if (UIController2_UI.FinalMap.name == "Map03_Desert")
        {
            // 선택한 맵의 아이콘 출력
            MapIcon.sprite = MapIcons[2];

            // 선택한 맵의 이름 출력
            MapTitle.text = "DESERT";
        }
    }

}
