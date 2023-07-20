using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationZone : MonoBehaviour
{
    [SerializeField] private float delayText = 0.03f;
    public TMP_Text tmpText;
    private string coment;
    public GameObject infoUIGroup;
    public Button checkBtn;
    public FindKeyPlayerMoveManager cubiMove;
    public FindLoadPlayerMoveManager2 cubiMove2;

    private void Start() 
    {
        tmpText.text = "";
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.name == "Char_Bull" && TutorialGameManager.tutorialCnt == 0)
        {
            switch(TutorialGameManager.infoCnt)
            {
                case 0:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "아일랜드의 신비한 비밀을 보려면, 열쇠가 필요해!\n네모난 틀에 아일랜드를 맞춰서, 나를 앞으로 움직여줘!";

                    InfoUIEnable();
                    break;

                case 1:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "앞이 낭떠러지 같지만, 나는 떨어지지 않아!\n계속 가볼까?";

                    InfoUIEnable();
                    break;

                case 2:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "앞이 막혔어!\n앞으로 갈 수 있게 아일랜드를 돌려줘!";
                    
                    InfoUIEnable();
                    break;
            }
        }

        if(other.transform.name == "Char_Bull" && TutorialGameManager.tutorialCnt == 1)
        {
            switch(TutorialGameManager.infoCnt)
            {
                case 0:
                    cubiMove2.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "우와! 아일랜드가 펼쳐졌어!\n이제 다른곳으로 떠나볼까?"
                            + "\n아일랜드를 바닥에 놓으면 더 편하게 이동할 수 있어!\n이제 앞으로 가볼까? 방향키를 움직여봐!";

                    InfoUIEnable();
                    break;

                case 1:
                    cubiMove2.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "빛나는 바닥은 넘어갈 수 있어\n계속 앞으로 가볼까?";

                    InfoUIEnable();
                    break;

                case 2:
                    cubiMove2.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "이제 다 왔어!\n얼굴이 도착지에 닿으면 새로운 세상으로 이동할 수 없으니 조심해줘!";
                    
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
