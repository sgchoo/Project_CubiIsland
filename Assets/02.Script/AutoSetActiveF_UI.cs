using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetActiveF_UI : MonoBehaviour
{
    private float fadeDuration;
    private CanvasGroup DisappearObject;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 2f)
        {
            StartCoroutine(FadeOutIcon());
        }
        

    }

    // transition 효과 주기
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
}
