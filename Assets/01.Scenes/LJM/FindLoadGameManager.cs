using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindLoadGameManager : MonoBehaviour
{

    public TMP_Text timerText;   
    public GameObject missionPanel;
    public GameObject multiTarget;
    public bool startTimer = false;
    public GameObject successPanel;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }

    private bool isStart = false;
    // Update is called once per frame
    void Update()
    {
        if(!isStart && TouchManager.isTouch) 
        {
            gameOver = false;
            missionPanel.SetActive(false);
            isStart = true;
            multiTarget.SetActive(true);
            return;
        }

        if(gameOver) return;
        if(!gameOver && DestinationManager.clear)
        {
            successPanel.SetActive(true);
            GameData.Instance.currentGame = 0;
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
    
        multiTarget.SetActive(true);
        startTimer = false;
    }
}
