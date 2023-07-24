using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;
using Vuforia;

public class GameController_UI : MonoBehaviour
{
    [Header("08.키찾기_미션타이틀")]
    public TextMeshProUGUI Key_MissionText;
    [Header("09.길찾기_미션타이틀")]
    public TextMeshProUGUI Road_MissionText;

    [Header("진행시간 표시")]
    public TextMeshProUGUI timer;

    [Header("XR OriginTarget")]
    public GameObject XROrigin;



    // 이미지 타겟
    public GameObject arrayImageTarget;
    private GameObject imageTarget;
    //public GameObject multiTarget;
    //public Transform cube;
    private bool isDetect;
    private bool isCameraOn;


    // Start is called before the first frame update
    void Start()
    {
        isDetect = false;
        isCameraOn = false;
        // 씬 이름 체크해서 08.Key씬인 경우 ---------------------
        // UIController_FinalMap의 이미지만 카메라에 인식되도록 하기
        // 인식되면 08.미션창 띄우기
        // 미션 타이틀 text 바꾸기 : 키찾기!
        // if (SceneManager.GetActiveScene().name == "08.FindKeyScene")
        if (SceneManager.GetActiveScene().name == "07_2.LoadScene")
        {
            FindKeyControl();
            if (GameObject.Find("/Canvas08/PanelSafeArea/PanelGameLoading") != null)
            {
                GameObject.Find("/Canvas08/PanelSafeArea/PanelGameLoading").SetActive(true);
            }
        }

        // 씬 09.인 경우 ----------------------------------------
        // 바로 09.미션창 띄우기
        // 미션 타이틀 text 바꾸기 : 길찾기!
        if (SceneManager.GetActiveScene().name == "09.FindRoadScene")
        {
            FindRoadControl();
        }

        // 공통으로 -> 미션창 터치하면 3초뒤 게임 시작하기 / isPlaying = true
        // 게임 시작하면 타임 표시하기

        //

    }

    // Update is called once per frame
    void Update()
    {
        if (!isCameraOn && PanelLoading_UI.ActAR)
        {
            ActImageTarget();
            isCameraOn = true;
        }
    }

    private void ActImageTarget()
    {
        // 이미지 타겟 켜기
        // XROrigin.SetActive(true);
        // XRSettings.enabled = true;

        int len = arrayImageTarget.transform.childCount;
        for (int idx = 0; idx < len; idx++)
        {
            Transform target = arrayImageTarget.transform.GetChild(idx);
            if (target.name == UIController2_UI.FinalMap.name)
            {
                imageTarget = target.gameObject;
                imageTarget.SetActive(true);
            }
        }
        if (imageTarget == null)
        {
            Debug.Log("Error!!");
        }

    }



    public void FocusedImage()
    {
        Debug.Log(imageTarget.GetComponentInParent<ObserverBehaviour>().TargetName + ",  " + UIController2_UI.FinalMap.name);
        if (imageTarget.GetComponentInParent<ObserverBehaviour>().TargetName == UIController2_UI.FinalMap.name)
        {
            Invoke("DelayLoadScene", 1f);
            
            // imageTarget.SetActive(false);
            // arrayImageTarget.SetActive(false);
            // // cube.gameObject.SetActive(true);
            // isDetect = true;
        }

    }

    private void DelayLoadScene()
    {
        SceneManager.LoadScene("08.FindKeyScene");
    }

    // public void FocusedMultiTarget()
    // {
    //     if(isDetect) cube.gameObject.SetActive(true);
    // }

    private void FindKeyControl()
    {
        // 선택된 맵 데이터 가져오기

    }

    private void FindRoadControl()
    {

    }
}
