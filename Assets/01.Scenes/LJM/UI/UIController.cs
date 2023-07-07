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

    //타이틀 이동 버튼 로직
    public void btnTitle() { SceneMove(KeyStore.titleScene); }

    //로비 이동 버튼 로직
    public void btnLobby() { SceneMove(KeyStore.lobbyScene); }


    // 씬 이동 로직
    private void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
