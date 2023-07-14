using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationZone : MonoBehaviour
{
    [SerializeField] private float delayText = 0.3f;
    public TMP_Text tmpText;
    private string coment;
    public GameObject infoUIGroup;
    public Button checkBtn;
    public FindKeyPlayerMoveManager cubiMove;

    private void Start() 
    {
        tmpText.text = "";
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.name == "Char_Bull")
        {
            switch(TutorialGameManager.infoCnt)
            {
                case 0:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "앞으로 끝까지 가세용";

                    InfoUIEnable();
                    break;

                case 1:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "같은 방향으로 계속가면 넘어가용";

                    InfoUIEnable();
                    break;

                case 2:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "가고싶은 방향으로 큐브를 돌려 방향을 바꿔보세용";
                    
                    InfoUIEnable();
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Destroy(this.gameObject);
    }

    private void InfoUIEnable()
    {
        infoUIGroup.SetActive(true);

        StartCoroutine(InfoText(delayText));
    }

    IEnumerator InfoText(float during)
    {
        for(int i = 0; i < coment.Length; i++)
        {
            tmpText.text += coment[i];

            yield return new WaitForSeconds(during);

            if(tmpText.text.Length == coment.Length)
            {
                checkBtn.gameObject.SetActive(true);
                break;
            }
        }
    }
}