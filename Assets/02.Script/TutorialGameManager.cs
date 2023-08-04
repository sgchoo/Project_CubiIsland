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
    public static bool isChatting;
    public static int textCount;
    public GameObject infoUIGroup;
    public GameObject successUIGroup;
    public Button checkBtn;
    public Button nextBtn;
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

        SetButton();
    }

    private void SpreadOut()
    {
        if(getKeyCount != 0)
        {
            tutorialCnt = 1;
            infoCnt = 0;
            getKeyCount = 0;
            // 성공 UI
            Invoke("DelayMoveScene",1f);
            
            SFXSoundManager.Instance.TutorialClearSound();
        }
    }

    public void DelayMoveScene()
    {
        successUIGroup.SetActive(true);
    }

    private void FinishTutorialGame()
    {
        if(isFinish)
        {
            tutorialCnt = 0;
            infoCnt = 0;
            isFinish = false;
            // 성공 UI
            Invoke("DelayMoveScene",1f);

            SFXSoundManager.Instance.TutorialClearSound();
        }
    }

    public void CheckBtn()
    {
        isChatting = false;
        textCount = 0;
        infoCnt++;
        cubiMove.rotateSpeed = 80f;
        cubiMove2.rotateSpeed = 80f;
        checkBtn.gameObject.SetActive(false);
        infoUIGroup.SetActive(false);
    }

    public void NextBtn()
    {
        textCount++;
        isChatting = false;
        nextBtn.gameObject.SetActive(false);
    }

    private void SetButton()
    {
        if(tutorialCnt == 0 && textCount == 1 && infoCnt == 0)
        {
            nextBtn.gameObject.SetActive(false);
            checkBtn.gameObject.SetActive(true);
        }

        if(tutorialCnt == 1 && textCount == 2 && infoCnt == 0)
        {
            nextBtn.gameObject.SetActive(false);
            checkBtn.gameObject.SetActive(true);
        }

        if(infoCnt != 0)
        {
            nextBtn.gameObject.SetActive(false);
            checkBtn.gameObject.SetActive(true);
        }
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
