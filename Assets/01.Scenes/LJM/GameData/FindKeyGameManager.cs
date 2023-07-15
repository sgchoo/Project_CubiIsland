using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FindKeyGameManager : MonoBehaviour
{
    public int keyToFind = 2;
    public static int currentKeyCount = 0;
    public GameObject successPanel;
    public TMP_Text unlockCharacterName;
    public GameObject descriptionPanel;

    public GameObject multiView;

    public static bool gameOver;
    private bool isStart = false;
    private void Start()
    {        
        if (keyToFind == 0) keyToFind = 2;
        currentKeyCount = 0;
        gameOver = true;
        isStart = false;
        descriptionPanel.SetActive(true);
        successPanel.SetActive(false);
        multiView.SetActive(false); 

        Debug.Log("FINDKEYGAMEMANAGER::"+GameData.Instance.characterLockList.Count);
    }

    
    private void Update()
    {
        Debug.Log("FINDKEYGAME::"+isStart + " Touch::" + TouchManager.isTouch + " " + (isStart == TouchManager.isTouch));
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
            

            Image unLockCharacter = successPanel.transform.Find("SuccessPanel").transform.Find("ImageItem").GetComponent<Image>();
            unLockCharacter.sprite = GameData.Instance.characterLockList[GameData.Instance.characterUnLockIdx].transform.Find("Image").GetComponent<Image>().sprite;

            GameData.Instance.characterUnLockIdx += 1;
            PlayerPrefs.SetInt(KeyStore.CHARACTER_UNLOCK_INDEX, GameData.Instance.characterUnLockIdx);
            PlayerPrefs.Save();
            //unLockCharacter.sprite = 
            //unlockCharacterImage.sprite = 
            // int unLockcount = GameData.Instance.characterUnLockIdx;
            // int idx

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
