
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindLoadGameManager : MonoBehaviour
{

    public TMP_Text timerText;   
    public GameObject missionPanel;
    //public GameObject multiTarget;
    public bool startTimer = false;
    public GameObject successPanel;
    private bool isStart = false;
    private bool gameOver = false;
    public GameObject arrayImageTarget;
    private GameObject imageTarget;

    public Sprite[] mapIcont;
    void Start()
    {
        gameOver = false;
        isStart = false;
        successPanel.SetActive(false);
        missionPanel.SetActive(true);
        int len = arrayImageTarget.transform.childCount;
        for (int idx = 0; idx < len; idx++)
        {
            Transform target = arrayImageTarget.transform.GetChild(idx);
            target.gameObject.SetActive(false);
        }
        DestinationManager.clear = false;
        //StartCoroutine("Timer");
    }

    void Update()
    {
        if(!isStart && TouchManager.isTouch) 
        {
            gameOver = false;
            missionPanel.SetActive(false);
            isStart = true;
            DestinationManager.clear = false;
            ActImageTarget();
            //multiTarget.SetActive(true);
            return;
        }

        if(gameOver) return;
        if(!gameOver && DestinationManager.clear)
        {
            successPanel.SetActive(true);
            GameData.Instance.currentGame = 0;

            Image unLockMap = successPanel.transform.Find("SuccessPanel").transform.Find("ImageItem").GetComponent<Image>();
            unLockMap.sprite = mapIcont[GameData.Instance.worldUnLockIdx];

            GameData.Instance.worldUnLockIdx += 1;
            PlayerPrefs.SetInt(KeyStore.WORLD_UNLOCK_INDEX, GameData.Instance.worldUnLockIdx);
            PlayerPrefs.Save();
            // // int count = GameData.Instance.mapLockList.Count;
            // Debug.Log("Count : " + count);
            // int randomCount = Random.Range(0, count);
            // Debug.Log("RandomCount : " + randomCount);
            // // Transform target = GameData.Instance.mapLockList[randomCount].transform;
            // Debug.Log("target : " + target.name);
            // target.Find("Locked").gameObject.SetActive(false);
            gameOver = true;
        }

        
    }

    private IEnumerator Timer()
    {
        startTimer = true;
        timerText.text = "3";
        yield return new WaitForSeconds(1f);
        timerText.text = "2";
        yield return new WaitForSeconds(1f);
        timerText.text = "1";
        yield return new WaitForSeconds(1f);
        missionPanel.SetActive(false);
    
        //multiTarget.SetActive(true);
        ActImageTarget();
        startTimer = false;
    }

    private void ActImageTarget()
    {
        int len = arrayImageTarget.transform.childCount;
        for (int idx = 0; idx < len; idx++)
        {
            Transform target = arrayImageTarget.transform.GetChild(idx);
            if (target.name == "Map01_Forest"/*GameData.Instance.currentWorld.name*/)
            {
                Debug.Log("qwe");
                imageTarget = target.gameObject;
                imageTarget.SetActive(true);
                break;
            }
        }

        if (imageTarget == null)
        {
            Debug.Log("Error!!");
        }
        // isCameraOn = true;
    }
}
