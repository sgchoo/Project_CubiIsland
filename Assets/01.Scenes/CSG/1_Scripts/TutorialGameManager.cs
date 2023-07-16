using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialGameManager : MonoBehaviour
{
    public static int getKeyCount;
    public static int infoCnt;
    public static int tutorialCnt;
    public static bool isFinish;
    private string coment;
    public GameObject infoUIGroup;
    public Button checkBtn;
    public TMP_Text tmpText;
    public FindKeyPlayerMoveManager cubiMove;
    public FindLoadPlayerMoveManager2 cubiMove2;

    private void SpreadOut()
    {
        if(getKeyCount != 0)
        {
            GameObject[] joints = GameObject.FindGameObjectsWithTag("Joint");

            foreach (var joint in joints)
            {
                tutorialCnt = 1;
                joint.GetComponent<OpenBox>().enabled = true;
                // 성공 UI

                // 씬 넘기기

            }
        }
    }

    private void FinishTutorialGame()
    {
        if(isFinish)
        {
            tutorialCnt = 0;
            isFinish = false;
            // 성공 UI

            // 씬 넘기기

        }
    }

    public void CheckBtn()
    {
        infoCnt++;
        cubiMove.rotateSpeed = 60.6f;
        cubiMove2.rotateSpeed = 50f;
        checkBtn.gameObject.SetActive(false);
        infoUIGroup.SetActive(false);
    }
}
