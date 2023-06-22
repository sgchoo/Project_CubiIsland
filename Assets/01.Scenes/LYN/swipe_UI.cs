using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class swipe_UI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("터치");
    }
    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("터치");
    }
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;

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
                rectTransform.GetChild(i).localScale = Vector2.Lerp(rectTransform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        rectTransform.GetChild(j).localScale = Vector2.Lerp(rectTransform.GetChild(j).localScale, new Vector2(0.5f, 0.5f), 0.1f);
                    }
                }
            }

        }
    }
}
