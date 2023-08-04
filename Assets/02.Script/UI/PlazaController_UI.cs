using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlazaController_UI : MonoBehaviour
{
    [Header("캐릭터 & 맵 프리팹 생성")]
    public GameObject Char_04, Map_04;

    private GameObject PreviewChar;
    private GameObject PreviewMap;


    void Start()
    {
        if(GameData.Instance.plazaWorld != null)
        {
            GameData.Instance.plazaWorld.SetActive(true);
        }
        if(GameData.Instance.tutorialPlaza)
        {
            Invoke("DelayLoadAsyncTutorial", 2f);
        }
        // Debug.Log("4번씬");
        // SetChar();
        // SetMap();
    }

    public void DelayLoadAsyncTutorial()
    {
        SceneManager.LoadSceneAsync(KeyStore.tutorialPlaza, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetChar()
    {
        if (UIController2_UI.FinalChar == null)
        {
            Debug.Log("UI프리팹 소실");
        }
        else
        {
            Debug.Log("UI컨트롤러 프리팹임");
            GameObject newObject = Instantiate(UIController2_UI.FinalChar) as GameObject;
            newObject.transform.SetParent(Char_04.transform, false);
            PreviewChar = newObject;
        }
    }

    public void SetMap()
    {
        if (UIController2_UI.FinalMap == null)
        {
            Debug.Log("UI프리팹 소실");
        }
        else
        {
            Debug.Log("UI컨트롤러 프리팹임");
            GameObject newObject = Instantiate(UIController2_UI.FinalMap) as GameObject;
            newObject.transform.SetParent(Map_04.transform, false);
            PreviewMap = newObject;
        }
    }

    // 임시로 버튼 누르면 씬 로드하게 넣어놨음 -> 오브젝트 충돌 시 넘어가도록 수정 요망
    public void btnTempChar() { SceneManager.LoadScene(KeyStore.characterSelectScene);}
    public void btnTempMap() { SceneManager.LoadScene(KeyStore.worldSelectScene);}

}
