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

    public void tutoBtnClick()
    {
        yesOrNoCanvas.SetActive(true);
    }
    // Start is called before the first frame update
    void OnClickYes()
    {
        moveSceneName = "";
        string name = SceneManager.GetActiveScene().name;
        if(name == KeyStore.findKeyScene)
        {
            moveSceneName = KeyStore.tutorialFindKeyGame;
        }
        else if (name == KeyStore.findLoadScene) 
        {
            moveSceneName = KeyStore.tutorialFindRoadGame;
        }
        else
        {
            Debug.Log("TutorialYesOrNo::Error-no relationship");
            return;
        }
        SceneManager.LoadScene(moveSceneName);
    }

    public void OnClickNo()
    {
        yesOrNoCanvas.SetActive(false);
    }
}
