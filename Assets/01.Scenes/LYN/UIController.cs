using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    
    public GameObject PanelGuide, PanelChoose;

    [SerializeField]
    public static UIController instance;
    public Scene CurrentScene;

    static int PanelNum = 0;

    public bool SceneLoad;

    // UIController 프리팹 만들기
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (SceneLoad == true)
        {
            print("씬 로드된 것을 UIController가 확인");
            CurrentScene = SceneManager.GetActiveScene();
            if (CurrentScene.name == "02.LobbyScene_UI" || PanelNum == 1)
            {
                PanelGuideOpen();
            }
        }
    }



    //01.GameGuide - 02.PanelGuide
    public void btnGameGuide()
    {
        Debug.Log("게임안내");
        PanelNum = 1;
        SceneManager.LoadScene("02.LobbyScene_UI");
    }

    //01.GameStart - 02. PanelChoose
    public void btnGameStart()
    {
        Debug.Log("게임시작");
        PanelNum = 2;
        SceneManager.LoadScene("02.LobbyScene_UI");
    }

    //02. Panelchoose - 01.TitleScene
    public void btnGoBack()
    {
        Debug.Log("뒤로가기");
        SceneManager.LoadScene("01.TitleScene_UI");
    }

    public void btnOption()
    {
        Debug.Log("옵션창");
        SceneManager.LoadScene("99.OptionScene_UI");
    }

    private void PanelGuideOpen()
    {
        if (CurrentScene.name == "02.LobbyScene_UI" || PanelNum == 1)
        {
            print("패널가이드 오픈 됨");
            
            GameObject PanelGuide = GameObject.Find("Canvas02/PanelSafeArea/PanelGuide");
            GameObject PanelChoose = GameObject.Find("Canvas02/PanelSafeArea/PanelChoose");
            
        }
    }

    private void PanelChooseOpen()
    {
        if (CurrentScene.name == "02.LobbyScene_UI" || PanelNum == 2)
        {
            GameObject PanelGuide = GameObject.Find("Canvas02/PanelSafeArea/PanelGuide");
            GameObject PanelChoose = GameObject.Find("Canvas02/PanelSafeArea/PanelChoose");
            PanelGuide.SetActive(false);
            PanelChoose.SetActive(true);
        }
    }

}
