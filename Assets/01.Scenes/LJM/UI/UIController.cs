using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //타이틀 이동 Scene 버튼 로직
    public void btnTitle() { SceneMove(KeyStore.titleScene); }

    //로비 이동 Scene 버튼 로직
    public void btnLobby() { SceneMove(KeyStore.lobbyScene); }

    // 광장 생성 Scene 이동 버튼 로직
    public void btnCreatePlaza() { SceneMove(KeyStore.createPlazaScene); }

    // 광장 Scene 이동 버튼 로직
    public void btnPlaza() 
    {
        SceneMove(KeyStore.plazaScene); 
    }

    public void btnPlazaCheck()
    {
        if(GameData.Instance.plazaWorld != null) SceneMove(KeyStore.plazaScene);
        else SceneMove(KeyStore.createPlazaScene);
    }

    public void btnBackPlaza()
    {
        if (GameData.Instance.plazaWorld != null) SceneMove(KeyStore.plazaScene);
        else SceneMove(KeyStore.createPlazaScene);
    }

    // 본 게임 시작 전 큐브 체크 Scene 이동 버튼 로직
    public void btnStartCheck() { SceneMove(KeyStore.startCheckScene); }

    // FindKeyGame Scene 이동 버튼 로직
    public void btnLoadScene() { SceneMove(KeyStore.loadScene); }

    public void btnFindKeyScene() 
    {
        if(GameData.Instance.tutorialFindKey) SceneMove(KeyStore.tutorialFindKeyGame);
        else SceneMove(KeyStore.findKeyScene);
    }

    public void btnFindRoadScene() 
    {
        if(GameData.Instance.tutorialFindRoad) SceneMove(KeyStore.tutorialFindRoadGame);
        else SceneMove(KeyStore.findLoadScene);
    }

    // 튜토리얼 출력 버튼 로직
    public void btnTutorial() { Debug.Log("튜토리얼 출력"); }

    public void btnTutorialPlazaEnd() 
    {
        GameData.Instance.tutorial = false;
        GameData.Instance.tutorialPlaza = false;
        PlayerPrefs.SetInt(KeyStore.TUTORIAL_PLAZA_KEY, 1);
        PlayerPrefs.Save();
        SceneManager.UnloadSceneAsync(KeyStore.tutorialPlaza);
        SceneManager.LoadScene(KeyStore.plazaScene);
    }

    public void btnTutorialFindKeyGameEnd() 
    {
        GameData.Instance.tutorialFindKey = false;
        PlayerPrefs.SetInt(KeyStore.TUTORIAL_FIND_KEYGAME_KEY, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(KeyStore.findKeyScene);
    }
    
    public void btnTutorialFindRoadGameEnd() 
    {
        GameData.Instance.tutorialFindRoad = false;
        PlayerPrefs.SetInt(KeyStore.TUTORIAL_FIND_ROAD_KEY, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(KeyStore.findLoadScene);
    }
 
 


    private string optionPrevSceneName;
    // 옵션 씬 관련
    public void btnOptionLoad()
    {
        //optionPrevSceneName = KeyStore
        SceneManager.LoadSceneAsync(KeyStore.optionScene, LoadSceneMode.Additive);
    }

    public void btnOptionUnLoad()
    {
        SceneManager.UnloadSceneAsync(KeyStore.optionScene);
    }
    // 옵션 씬 관련 끝

    public void GoLink()
    {
        Debug.Log("Go");
        // ImageDownloadManager downloadManager = new ImageDownloadManager();
        // downloadManager.DownloadImage();
        new ImageDownloadManager().DownloadObject();
    }

    // 씬 이동 로직
    private void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    

}
