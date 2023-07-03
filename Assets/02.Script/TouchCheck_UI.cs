using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public static bool isTouch = false;

    void Update()
    {
        // PC 클릭 체크
        if (Input.GetMouseButtonDown(0))
        {
            // PC 클릭 동작 처리
            Debug.Log("터치");
            isTouch = true;
        }

        // 모바일 터치 체크
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouch = true;
            }
            else if (touch.phase == TouchPhase.Ended && isTouch)
            {
                isTouch = false;
                // 모바일 터치 동작 처리
                //Debug.Log("모바일 터치 발생");
            }
        }
    }
}
