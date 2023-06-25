using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class swipe_UI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Color[] colors;
    private Button takeTheBtn;
    int btnNumber;
    private RectTransform rectTransform;
    public GameObject scrollbar, ButtonContent;
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
                Debug.Log("Current Selected Level" + i);
                rectTransform.GetChild(i).localScale = Vector2.Lerp(rectTransform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        rectTransform.GetChild(j).localScale = Vector2.Lerp(rectTransform.GetChild(j).localScale, new Vector2(0.6f, 0.6f), 0.1f);
                    }
                }
            }

        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Level" + i);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                ButtonContent.transform.GetChild(i).localScale = Vector2.Lerp(ButtonContent.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                ButtonContent.transform.GetChild(i).GetComponent<Image>().color = colors[1];
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        ButtonContent.transform.GetChild(j).GetComponent<Image>().color = colors[0];
                        ButtonContent.transform.GetChild(j).localScale = Vector2.Lerp(ButtonContent.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }

        }
        
    }
    //버튼 색상 바꾸기
        public void WhichBtnClicked(Button btn)
        {
            btn.transform.name = "clicked";
            for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
            {
                if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
                {
                    btnNumber = i;
                    takeTheBtn = btn;
                    scroll_pos = (pos[btnNumber]);
                }
            }
        }
}
