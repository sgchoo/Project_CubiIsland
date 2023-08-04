using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;


public class UIController2_UI : MonoBehaviour
{
    [SerializeField]
    public static UIController2_UI instance;

    public Scene CurrentScene;

    public static GameObject FinalMap;
    public static GameObject FinalChar;

    private string previousSceneName;



    [Header("선택 캐릭터")]
    [SerializeField] private string Char;

    [Header("선택 맵")]
    [SerializeField] private string Map;


    void Awake()
    {
        // 현재 씬의 직전 씬 이름 저장
        previousSceneName = SceneManager.GetActiveScene().name;
    }


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
            print("UI컨트롤러 다시 만들게");
            if (FinalChar != null || FinalMap != null)
            {
                Destroy(gameObject);
                FinalChar = ChangeController_UI.CurrentChar;
                FinalMap = MapListController_UI.CurrentMap;
            }

        }
        DefaultSet();
    }

    // Update is called once per frame
    void Update()
    {
        //유니티 창에 보여주기 위한 용도
        Char = FinalChar.name;
        Map = FinalMap.name;
    }

    public bool PlayerAssetCheck()
    {
        return FinalChar != null && FinalMap != null;
    }

    private void DefaultSet()
    {
        if (FinalChar != null || FinalMap != null)
        {
            FinalChar = ChangeController_UI.CurrentChar;
            FinalMap = MapListController_UI.CurrentMap;
        }
        else
        {
            //게임 시작 시 기본 캐릭터와 맵을 설정합니다.
            FinalMap = Resources.Load<GameObject>("Map01_Forest");
            FinalChar = Resources.Load<GameObject>("Char_PolarBear");
        }
    }

    //타이틀로 이동
    public void btnTitle() {        SceneManager.LoadScene("01.TitleScene"); }
    //로비로 이동
    public void btnLobby() {        SceneManager.LoadScene("02.LobbyScene"); }
    // 광장 생성으로 이동
    public void btnCreatePlaza() {  SceneManager.LoadScene("03.CreatePlazaScene"); }

    // 시작 전 큐브 체크 패널로 이동
    public void btnStartCheck() {   SceneManager.LoadScene("07.StartCheckScene"); }

    public void btnPlaza() {        SceneManager.LoadScene("04.PlazaScene"); }

    // public void btnStart() {        SceneManager.LoadScene("08.FindKeyScene"); }
    public void btnStart() {        SceneManager.LoadScene("07_2.LoadScene"); }

    public void btnGameRoad() {     SceneManager.LoadScene("09.FindRoadScene"); }

    // 옵션씬 가져오기. 공부해야함.
    public void btnOption() {       SceneManager.LoadScene("99.OptionScene");}
    public void GoBack() {          SceneManager.LoadScene(previousSceneName);}



}
