 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameLoadingManager : MonoBehaviour
{
    // XR 카메라 ON/OFF 체크용 변수
    public static bool isDetectPanel = false;
    public static bool isCameraOn = false;

    public GameObject sliderLoadingPanel;
    public GameObject imageLoadingPanel;


    // 이미지 타겟
    public GameObject arrayImageTarget;
    private GameObject imageTarget;

    // Start is called before the first frame update
    void Start()
    {
        isDetectPanel = false;
        isCameraOn = false;
        sliderLoadingPanel.SetActive(true);
        imageLoadingPanel.SetActive(false);
    }

    private bool isAct = false;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("GameLoadingManager::isDetectPanel:" + isDetectPanel);
        Debug.Log("GameLoadingManager::PanelLoading_UI.ActAR:" + PanelLoading_UI.ActAR);
        Debug.Log("GameLoadingManager::isCameraOn:" + isCameraOn);
        // if(sliderLoadingPanel.activeSelf) return; 
        // if(!isAct && imageLoadingPanel.activeSelf)
        // {
        //     if(!TouchManager.isTouch) return;
        //     else 
        //     {
        //         ActImageTarget();
        //         isAct = true;
        //     }
        // }
        if(isDetectPanel)
        {
            sliderLoadingPanel.SetActive(false);
            imageLoadingPanel.SetActive(true);
        }
        else if(!isCameraOn)
        {
            ActImageTarget();
        }
    }


    private void ActImageTarget()
    {
        int len = arrayImageTarget.transform.childCount;
        for (int idx = 0; idx < len; idx++)
        {
            Transform target = arrayImageTarget.transform.GetChild(idx);
            if (target.name == GameData.Instance.currentWorld.name)
            {
                imageTarget = target.gameObject;
                imageTarget.SetActive(true);
                break;
            }
        }
        if (imageTarget == null)
        {
            Debug.Log("Error!!");
        }
        isCameraOn = true;
    }

    public void FocusedImage()
    {
        if (isCameraOn)
        {
            Invoke("DelayLoadScene", 1f);
        }
        // if (imageTarget.GetComponentInParent<ObserverBehaviour>().TargetName == GameData.Instance.currentWorld.name)
        // {
        //     Invoke("DelayLoadScene", 1f);
        // }

    }

    private void DelayLoadScene()
    {
        string target = "";

        switch(GameData.Instance.currentGame)
        {
            case 0 : 
                if(GameData.Instance.tutorialFindKey)
                    target = KeyStore.tutorialFindKeyGame; 
                else 
                    target = KeyStore.findKeyScene; 
                break;
            case 1 : 
                if(GameData.Instance.tutorialFindRoad)
                    target = KeyStore.tutorialFindRoadGame; 
                else
                    target = KeyStore.findLoadScene; 
                    break;
            default : Debug.Log("Error!"); target = KeyStore.findKeyScene; break;
        }
        SceneManager.LoadScene(target);
    }
}
