using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController2_UI : MonoBehaviour
{
    [SerializeField]
    public static UIController2_UI instance;

    public Scene CurrentScene;


    [SerializeField]
    [Header("선택한 최종 큐비 캐릭터")]
    public static GameObject FianelChar;

    [SerializeField]
    [Header("선택한 최종 맵")]
    public static GameObject FinalMap;



    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    //타이틀로 이동
    public void btnTitle(){             SceneManager.LoadScene("01.TitleScene");}
    //로비로 이동
    public void btnLobby(){             SceneManager.LoadScene("02.LobbyScene");}
    // 광장 생성으로 이동
    public void btnCreatePlaza(){       SceneManager.LoadScene("03.CreatePlazaScene");}

    // 시작 전 큐브 체크 패널로 이동
    public void btnStartCheck(){        SceneManager.LoadScene("07.StartCheckScene");} 

    public void btnPlaza(){             SceneManager.LoadScene("04.PlazaScene");}

    public void btnStart(){             SceneManager.LoadScene("08.FindKeyScene");}

    public void btnGameRoad(){          SceneManager.LoadScene("09.FindRoadScene");}
    public void btnFinalChar(){         FianelChar = CharListController.CurrentObject;
                                        Debug.Log("최종 선택" + FianelChar.name);
                                        SceneManager.LoadScene("04.PlazaScene");}
    public void btnFinalMap(){          //맵 리스트 스크립트 만들어서 선택된 프리팹 가져오기
                                        //FinalMap = MapListController.CurrentObject;
                                        SceneManager.LoadScene("04.PlazaScene");}
    public void btnOption(){ }      
}
