using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindKeyGameManager : MonoBehaviour
{
    public int keyToFind = 0;
    public static int currentKeyCount = 0;

    public FindKeyPlayerMoveManager player;
    public GameObject successPanel;

    private bool gameOver = false;

    private void Start()
    {        
        if (keyToFind == 0) keyToFind = 2;
        currentKeyCount = 0;
        gameOver = false;
    }

    private void Update()
    {
        if(gameOver) return;
        if(keyToFind == currentKeyCount)
        {
            player.enabled = false;
            successPanel.SetActive(true);
            GameData.Instance.currentGame = 1;
            int count = GameData.Instance.characterLockList.Count;
            int randomCount = Random.Range(0, count);

            Transform target = GameData.Instance.characterLockList[randomCount].transform;
            target.Find("locked").gameObject.SetActive(false);

            gameOver = true;
        }
    }

    public static void GetKey()
    {
        currentKeyCount+=1;
    }
}
