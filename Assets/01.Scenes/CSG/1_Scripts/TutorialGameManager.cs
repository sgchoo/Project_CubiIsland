using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialGameManager : MonoBehaviour
{
    public static int getKeyCount;
    public static int infoCnt;
    private string coment;
    public GameObject infoUIGroup;
    public Button checkBtn;
    public TMP_Text tmpText;
    public FindKeyPlayerMoveManager cubiMove;

    private void Update() 
    {
        if(getKeyCount != 0)
        {
            GameObject[] joints = GameObject.FindGameObjectsWithTag("Joint");

            foreach (var edge in joints)
            {
                edge.GetComponent<OpenBox>().enabled = true;
            }
        }
    }

    public void CheckBtn()
    {
        infoCnt++;
        cubiMove.rotateSpeed = 60.6f;
        checkBtn.gameObject.SetActive(false);
        infoUIGroup.SetActive(false);
    }
}
