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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer) return;
        if(DestinationManager.clear)
        {
            Debug.Log("클리어!!");
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
