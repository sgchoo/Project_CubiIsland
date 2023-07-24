using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class swipe_UI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public static GameObject CurrentMap;
    public Color[] colors;
    private Button takeTheBtn;
    int btnNumber;
    private RectTransform rectTransform;
    public GameObject scrollbar, ButtonContent;
    public GameObject[] listBtns;               // 맵 리스트 표시 버튼 배열
    public GameObject FinBtn;
    public GameObject FinBtnEffect;

    float scroll_pos = 0;
    float[] pos;
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("터치");
    }
    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("터치");
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Color[] colors = new Color[2];
    }

    // Update is called once per frame
    void Update()
    {
        // 스와이프 스냅 
        // 자식 객체 갯수 배열로 가져오기
        pos = new float[rectTransform.childCount];
        // 
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        //마우스로 클릭 했을 때
        if (Input.GetMouseButton(0))
        {
            //스크롤 위치는 스크롤바 컴포넌트의 값
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                rectTransform.GetChild(i).localScale = Vector2.Lerp(rectTransform.GetChild(i).localScale, new Vector2(1.1f, 1.1f), 0.1f);
                CurrentMap = rectTransform.GetChild(i).gameObject;

                // 확대된 자식 객체 위치와 같은 위치(i)에 버튼 색상(yellow) 변경
                listBtns[i].GetComponent<Image>().color = colors[0];
                if(CurrentMap != null && CurrentMap.transform.Find("locked").gameObject.activeSelf)
                {
                    FinBtn.GetComponent<Button>().interactable = false;
                    FinBtnEffect.SetActive(false);
                }
                else 
                {
                    FinBtn.GetComponent<Button>().interactable = true;
                    FinBtnEffect.SetActive(true);
                }

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        rectTransform.GetChild(j).localScale = Vector2.Lerp(rectTransform.GetChild(j).localScale, new Vector2(0.65f, 0.65f), 0.1f);
                        // 확대되지 않은 부분은 버튼 색상(white)로 변경
                        listBtns[j].GetComponent<Image>().color = colors[1];
                    }
                }
            }

        }
    }
    // //버튼 색상 바꾸기
    //     public void WhichBtnClicked(Button btn)
    //     {
    //         btn.transform.name = "clicked";
    //         for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
    //         {
    //             if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
    //             {
    //                 btnNumber = i;
    //                 takeTheBtn = btn;
    //                 scroll_pos = (pos[btnNumber]);
    //             }
    //         }
    //     }
}
