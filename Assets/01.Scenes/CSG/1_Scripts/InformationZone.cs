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
                    coment = "이번 여정은 주변에 흩어져있는 열쇠를 찾아야해!!"
                             + "네모난 세상을 네모난 틀에 맞추면 위에 화살표의 색이 바뀔거야!"
                             + "그럼 우린 앞으로 갈 수 있어! 한 번 해볼까?";

                    InfoUIEnable();
                    break;

                case 1:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "내 바로 앞이 낭떨어지같지만 아니야!"
                             + "내 밑에 땅에 장애물이 없으면 나는 다음 땅으로 넘어갈 수 있어!"
                             + "한 번 해볼까?";

                    InfoUIEnable();
                    break;

                case 2:
                    cubiMove.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "내 앞이 가로막혀있다면 움직일 수 없어."
                             + "내가 가고싶은 방향으로 네모난 세상을 돌리면"
                             + "원하는 방향으로 바꿀 수 있어!";
                    
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
                    coment = "이번에는 다른 세상으로 갈 수 있는 길을 찾는 여정이야!"
                             + "오른쪽에 보이는 조이스틱으로 움직여서 노란색 포탈을 찾아줘!";

                    InfoUIEnable();
                    break;

                case 1:
                    cubiMove2.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "여기는 앞에 장애물이 있다고 하더라도 멈추지 않아도 돼" 
                            + "위에 네모난 표식이 되어있는 장애물은 넘어갈 수 있어!"
                            + "조이스틱으로 가던 방향으로 계속 움직여볼까?";

                    InfoUIEnable();
                    break;

                case 2:
                    cubiMove2.rotateSpeed = 0.01f;

                    tmpText.text = "";
                    coment = "이제 노란색 포탈이 보이는 것 같아!"
                             + "내가 포탈을 타고 이동하게 된다면 멀미날거 같아..."
                             + "내 얼굴이 바닥을 향하게 도착하지 않게 해줄래?";
                    
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
