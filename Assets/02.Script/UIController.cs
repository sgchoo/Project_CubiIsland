/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    
    //public GameObject PanelGuide, PanelChoose;

    [SerializeField]
    public static UIController instance;
    public Scene CurrentScene;

    static int PanelNum = 0;

    [SerializeField]
    [Header("선택한 최종 큐비 캐릭터")]
    public static GameObject CubiChar;

    //private SceneCheck_UI sceneCheck;

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

        // SceneCheck_UI의 인스턴스를 참조 하기 위한 함수, 애초에 static으로 해버리면 안써도 됨
        //sceneCheck = FindObjectOfType<SceneCheck_UI>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneCheck_UI.SceneLoad == true)
        {
            CurrentScene = SceneManager.GetActiveScene();
            Debug.Log("씬 " + CurrentScene.name + " / 패널" + PanelNum );
            
            if (CurrentScene.name == "02.LobbyScene_UI")
            {
                switch(PanelNum)
                {
                    case 0:
                        break;
                    case 1:
                        PanelGuideOpen();
                        break;
                    case 2:
                        PanelChooseOpen();
                        break;
                }
            }
            SceneCheck_UI.SceneLoad = false;
        }
    }

    public void btnGuide(){PanelNum = 1;    SceneManager.LoadScene("02.LobbyScene_UI");}

    public void btnLobby(){PanelNum = 2;    SceneManager.LoadScene("02.LobbyScene_UI");}

    public void btnGoBack(){                SceneManager.LoadScene("01.TitleScene_UI");}

    public void btnOption(){                SceneManager.LoadScene("99.OptionScene_UI");}
    public void btnCreatePlaza(){           SceneManager.LoadScene("03.DetectFloorScene_UI");}
    public void btnPlaza(){                 SceneManager.LoadScene("04.PlazaScene_UI");}
   
    public void btnGameStart(){             SceneManager.LoadScene("06.MapListScene_UI");}

    public void btnChar(){                  SceneManager.LoadScene("05.CharScene_UI");}
    public void btnCubiChoose() {           CubiChar = CharListController.CurrentObject;
                                            Debug.Log("최종 선택" + CubiChar.name);
                                            SceneManager.LoadScene("04.PlazaScene_UI");}

    private void PanelGuideOpen()
    {
        if (CurrentScene.name == "02.LobbyScene_UI" || PanelNum == 1)
        {
            Debug.Log(PanelNum + "번 PanelGuide");
            GameObject PanelGuide = GameObject.Find("Canvas02/PanelSafeArea/PanelGuide01");
            GameObject PanelChoose = GameObject.Find("Canvas02/PanelSafeArea/PanelChoose02");
            PanelGuide.SetActive(true);
            PanelChoose.SetActive(false);
        }
    }

    private void PanelChooseOpen()
    {
        if (CurrentScene.name == "02.LobbyScene_UI" || PanelNum == 2)
        {
            Debug.Log(PanelNum + "번 PanelChoose");
            GameObject PanelGuide = GameObject.Find("Canvas02/PanelSafeArea/PanelGuide01");
            GameObject PanelChoose = GameObject.Find("Canvas02/PanelSafeArea/PanelChoose02");
            PanelGuide.SetActive(false);
            PanelChoose.SetActive(true);
        }
    }

}
 */