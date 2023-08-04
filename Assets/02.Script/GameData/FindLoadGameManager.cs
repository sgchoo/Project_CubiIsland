
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

    public GameObject guide03;
    public GameObject guide04;
    public TMP_Text getMapName;

    public GameObject particle;
    private GameObject prevParticle;

    public List<string> unLockName = new List<string>(){"Snow", "Desert", "Beach", "City", "Playground"};
    public Sprite[] mapIcont;
    void Start()
    {
        gameOver = false;
        isStart = false;
        successPanel.SetActive(false);
        missionPanel.SetActive(true);
        guide03.SetActive(true);
        guide04.SetActive(true);
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
        if(!isStart && guide03.activeSelf) 
        {
            if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                gameOver = false;
                guide03.SetActive(false);
            }
            return;
        }
        else if(!isStart && guide04.activeSelf)
        {
            if(Input.touchCount>0 &&Input.GetTouch(0).phase == TouchPhase.Began)
            {
                missionPanel.SetActive(false);  
                isStart = true;
                DestinationManager.clear = false;
                ActImageTarget();
            }
        }


        if(gameOver) return;
        if(!gameOver && DestinationManager.clear)
        {
            Invoke("DelayOpenPanel",1f);
            SFXSoundManager.Instance.MainGameClearSound();
            
            GameData.Instance.currentGame = 0;

            Image unLockMap = successPanel.transform.Find("SuccessPanel").transform.Find("ImageItem").GetComponent<Image>();
            unLockMap.sprite = mapIcont[GameData.Instance.worldUnLockIdx];
            getMapName.text = unLockName[GameData.Instance.worldUnLockIdx];

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
        // isCameraOn = true;
    }
    public void DelayOpenPanel()
    {
        successPanel.SetActive(true);
    }

}
