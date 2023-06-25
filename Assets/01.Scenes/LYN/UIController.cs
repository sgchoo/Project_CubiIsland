using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [Header("PanelGuide")]
    public GameObject PanelGuide;
    [Header("PanelChoose")]
    public GameObject PanelChoose;

    [SerializeField]
    public static UIController instance;

    //static int num = 0;

    static bool isOn = false;

    void Awake()
    {
        // 인스턴스가 이미 있는지 확인, 이 상태로 설정
        if (instance == null)
            instance = this;

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (instance != this)
            Destroy(gameObject);

        // 다음 scene으로 넘어가도 오브젝트 유지
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(num == 1){PanelGuideOpen();}
        if(isOn == true){PanelGuideOpen();}
    }

    //01.GameGuide - 02.PanelGuide
    public void btnGameGuide()
    {
        Debug.Log("게임안내");
        isOn = true;
        //num++;
        SceneManager.LoadScene("02.LobbyScene_UI");
    }

    //01.GameStart - 02. PanelChoose
    public void btnGameStart()
    {
        Debug.Log("게임시작");
        SceneManager.LoadScene("02.LobbyScene_UI");
        
        //PanelChoose로 연결

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
        GameObject objectC = GameObject.Find("Canvas02/PanelSafeArea/PanelGuide");
        PanelGuide = objectC;
        GameObject objectD = GameObject.Find("Canvas02/PanelSafeArea/PanelChoose");
        

        //PanelGuide.SetActive(true); 이 코드가 되어야 하는데 안됨 ㅠㅠ null 뜸.. 왜인지를 모르겠음
        //PanelGuide.SetActive(false);
    }

}
