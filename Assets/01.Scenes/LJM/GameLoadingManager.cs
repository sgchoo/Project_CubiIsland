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

    // Update is called once per frame
    void Update()
    {
        if(isDetectPanel && !PanelLoading_UI.ActAR)
        {
            sliderLoadingPanel.SetActive(false);
            imageLoadingPanel.SetActive(true);
        }
        else if(!isCameraOn && PanelLoading_UI.ActAR)
        {
            ActImageTarget();
        }
        else if(isCameraOn)
        {
            FocusedImage();
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
        if (imageTarget.GetComponentInParent<ObserverBehaviour>().TargetName == GameData.Instance.currentWorld.name)
        {
            Invoke("DelayLoadScene", 1f);
        }

    }

    private void DelayLoadScene()
    {
        Debug.Log("8번씬너머로");
        SceneManager.LoadScene(KeyStore.findKeyScene);
    }
}
