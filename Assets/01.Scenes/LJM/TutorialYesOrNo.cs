using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialYesOrNo : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject currentUI;
    public GameObject yesOrNoCanvas;
    private string moveSceneName;
    // Start is called before the first frame update
    void Start()
    {
        moveSceneName = "";
        string name = SceneManager.GetActiveScene().name;
        if(name == KeyStore.findKeyScene)
        {
            if(GameData.Instance.tutorialFindKey)
            {
                currentUI.SetActive(false);
                gameManager.SetActive(false);
                yesOrNoCanvas.SetActive(true);
                moveSceneName = KeyStore.tutorialFindKeyGame;
            }
        }
        else if (name == KeyStore.findLoadScene) 
        {
            if(GameData.Instance.tutorialFindRoad)
            {
                currentUI.SetActive(false);
                gameManager.SetActive(false);
                yesOrNoCanvas.SetActive(true);
                moveSceneName = KeyStore.tutorialFindRoadGame;
            }
        }
        else
        {
            currentUI.SetActive(true);
            gameManager.SetActive(true);
            yesOrNoCanvas.SetActive(false);
            this.gameObject.SetActive(false);
        }
        
    }

    private void SceneMove(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnClickYes()
    {
        SceneMove(moveSceneName);
    }

    public void OnClickNo()
    {
        currentUI.SetActive(true);
        gameManager.SetActive(true);
        yesOrNoCanvas.SetActive(false);
        this.gameObject.SetActive(false);
}
}
