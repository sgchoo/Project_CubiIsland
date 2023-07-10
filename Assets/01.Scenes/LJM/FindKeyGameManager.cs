using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FindKeyGameManager : MonoBehaviour
{
    public int keyToFind = 0;
    public static int currentKeyCount = 0;
    public GameObject successPanel;
    public TMP_Text unlockCharacterName;
    public GameObject descriptionPanel;

    public GameObject multiView;

    public static bool gameOver;
    private bool isStart = false;
    private void Start()
    {        
        if (keyToFind == 0) keyToFind = 1;
        currentKeyCount = 0;
        gameOver = true;
        isStart = false;
        descriptionPanel.SetActive(true);
        successPanel.SetActive(false);
        multiView.SetActive(false); 
    }

    
    private void Update()
    {
        if(!isStart && TouchManager.isTouch) 
        {
            gameOver = false;
            descriptionPanel.SetActive(false);
            isStart = true;
            multiView.SetActive(true);
            return;
        }
        if(gameOver) return;
        if(keyToFind == currentKeyCount)
        {
            successPanel.SetActive(true);
            GameData.Instance.currentGame = 1;
            // int count = GameData.Instance.characterLockList.Count;
            // int randomCount = Random.Range(0, count);

            // Transform target = GameData.Instance.characterLockList[randomCount].transform;
            // target.Find("locked").gameObject.SetActive(false);
            // unlockCharacterName.text = target.gameObject.name;
            gameOver = true;
        }
    }

    public static void GetKey()
    {
        currentKeyCount+=1;
    }
}
