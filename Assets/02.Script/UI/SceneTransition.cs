using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private CanvasGroup canvasGroup;
    public float transitionDuration = 1.0f; // 전환 시간

    private float transitionTimer = 0f; // 전환 타이머
    private bool isTransitioning = false; // 전환 중인지 여부

    //private GameObject panel;

    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        // 캔버스에 연결된 CanvasGroup 컴포넌트를 가져옴
        canvasGroup = GetComponent<CanvasGroup>();

        sceneName = SceneManager.GetActiveScene().name;
        if ((sceneName == KeyStore.createPlazaScene) || (sceneName == KeyStore.loadScene) || (sceneName == KeyStore.plazaScene))
        {
            if (canvasGroup != null)
            {
                gameObject.SetActive(true);
                isTransitioning = true;
            }

        }
    }


    void Update()
    {
        if (isTransitioning)
        {
            // 전환 중인 경우 투명도를 서서히 감소시킴
            transitionTimer += Time.deltaTime;

            float progress = Mathf.Clamp01(transitionTimer / transitionDuration);
            canvasGroup.alpha = 1f - progress;

            // 전환 시간이 완료되면 씬을 로드하거나 다른 동작 수행
            if (transitionTimer >= transitionDuration)
            {

                if (sceneName == KeyStore.titleScene) { SceneManager.LoadScene(KeyStore.lobbyScene); }
                if (sceneName == KeyStore.lobbyScene) { SceneManager.LoadScene(KeyStore.createPlazaScene); }
                if ((sceneName == KeyStore.createPlazaScene) || (sceneName == KeyStore.loadScene)) { gameObject.SetActive(false); }
                if (sceneName == KeyStore.startCheckScene) { SceneManager.LoadScene(KeyStore.loadScene); }

                isTransitioning = false;
            }
        }
    }

    public void BtnSceneFadeout()
    {
        isTransitioning = true;
    }
}
