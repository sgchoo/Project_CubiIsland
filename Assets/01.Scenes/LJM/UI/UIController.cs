using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
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
    public void btnPlaza() { SceneMove(KeyStore.plazaScene); }

    // 본 게임 시작 전 큐브 체크 Scene 이동 버튼 로직
    public void btnStartCheck() { SceneMove(KeyStore.startCheckScene); } 

    // FindKeyGame Scene 이동 버튼 로직
    public void btnLoadScene() { SceneMove(KeyStore.loadScene); } 

    // 튜토리얼 출력 버튼 로직
    public void btnTutorial() { Debug.Log("튜토리얼 출력"); }



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


    // 씬 이동 로직
    private void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
