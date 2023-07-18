using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TutorialGameManager : MonoBehaviour
{
    public static int getKeyCount;
    public static int infoCnt;
    public static int tutorialCnt;
    public static bool isFinish;
    private string coment;
    public GameObject infoUIGroup;
    public GameObject successUIGroup;
    public Button checkBtn;
    public TMP_Text tmpText;
    public FindKeyPlayerMoveManager cubiMove;
    public FindLoadPlayerMoveManager2 cubiMove2;

    private string sceneName;
    private void Start() 
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Update() 
    {
        if      (KeyStore.tutorialFindKeyGame == sceneName)  SpreadOut();
        else if (KeyStore.tutorialFindRoadGame == sceneName) FinishTutorialGame();
        Debug.Log(tutorialCnt);
    }

    private void SpreadOut()
    {
        if(getKeyCount != 0)
        {
            tutorialCnt = 1;
            infoCnt = 0;
            // 성공 UI
            successUIGroup.SetActive(true);
        }
    }

    private void FinishTutorialGame()
    {
        if(isFinish)
        {
            tutorialCnt = 0;
            infoCnt = 0;
            isFinish = false;
            // 성공 UI
            successUIGroup.SetActive(true);
        }
    }

    public void CheckBtn()
    {
        infoCnt++;
        cubiMove.rotateSpeed = 60.6f;
        cubiMove2.rotateSpeed = 50f;
        checkBtn.gameObject.SetActive(false);
        infoUIGroup.SetActive(false);
    }

    public void MainFindKeyGame()
    {
        GameData.Instance.tutorialFindKey = false;
        PlayerPrefs.SetInt(KeyStore.TUTORIAL_FIND_KEYGAME_KEY, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(KeyStore.findKeyScene);
    }

    public void MainFindRoadGame()
    {
        GameData.Instance.tutorialFindRoad = false;
        PlayerPrefs.SetInt(KeyStore.TUTORIAL_FIND_ROAD_KEY, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(KeyStore.findLoadScene);
    }
}
