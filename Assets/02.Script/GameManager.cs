using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<summary>
// 각종 이벤트 데이터
// 종합 관리
//</summary>

public class GameManager : MonoBehaviour
{
    // 열쇠 찾기 게임 Key 갯수 카운트 변수
    public static int keyCount;
    
    // 찾아야할 열쇠 갯수
    [SerializeField] private float foundKeyCnt = 2;

    private void Update() 
    {
        KeyCountCheck();
    }

    // Key의 갯수 파악해서 전개도를 펼친다
    void KeyCountCheck()
    {
        // 만약 Key의 갯수가 foundKeyCnt와 같다면
        if(keyCount == foundKeyCnt)
        {
            // World Cube Map의 Rotation을 Zero로 바꿔준 후
            GameObject world = GameObject.FindWithTag("World");
            world.transform.localRotation = Quaternion.Euler(Vector3.zero);

            // Joint의 태그를 가진 오브젝트를 배열에 넣고
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Joint");

            // 각 오브젝트 자식 객체인 OpenBox의 활성화 여부 true로 변환시켜준다.
            foreach(var i in objs)
            {
                i.GetComponent<OpenBox>().enabled = true;
            }

            // 또한 PlayerCube또한 재위치 시켜준다.
            // 월드 꾸미고 바꾸기
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().enabled = false;
        }
    }
}
