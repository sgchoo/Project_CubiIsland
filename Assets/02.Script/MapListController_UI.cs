using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapListController_UI : MonoBehaviour
{
    public GameObject Contents;
    public int ContentNum;
    //맵 관련
    //[SerializeField]
    private GameObject[] MapList;
    public Sprite[] MapSourceList;

    //맵 아이콘 관련
    //[SerializeField]
    private GameObject[] IconList;
    public Sprite[] IconSourceList;



    void Start()
    {
        SetMapList();
        SetIconList();


    }

    // Update is called once per frame
    void Update()
    {

    }

    //맵 이미지 바꾸기
    private void SetMapList()
    {
        //컨텐츠 연결이 해제 된 경우
        if (Contents == null) { Debug.Log("Contents 오브젝트를 찾을 수 없습니다."); }

        else
        {
            // Content 자식의 갯수로 배열 만들기
            ContentNum = Contents.transform.childCount;

            //MapList 객체 받아오기
            MapList = new GameObject[ContentNum];

            for (int i = 0; i < ContentNum; i++)
            {
                //Content의 순서대로 MapList오브젝트 받아오기
                MapList[i] = Contents.transform.GetChild(i).gameObject;
                GameObject IconImage = MapList[i].transform.GetChild(0).gameObject;
                //MapList의 이미지 컴포넌트를 받아오기
                if (IconImage.tag == "MAPIMG")
                {
                    IconImage.GetComponent<Image>().sprite = MapSourceList[i];
                }
                //자식의 여러 tag 확인하기
                //GameObject[] childObject = GameObject.FindGameObjectsWithTag("MAPIMG");
            }
        }

    }
    private void SetIconList()
        {
            //컨텐츠 연결이 해제 된 경우
            if (Contents == null) { Debug.Log("Contents 오브젝트를 찾을 수 없습니다."); }

            else
            {
                // Content 자식의 갯수로 배열 만들기
                ContentNum = Contents.transform.childCount;

                //MapList 객체 받아오기
                IconList = new GameObject[ContentNum];

                for (int i = 0; i < ContentNum; i++)
                {
                    //Content의 순서대로 IconList오브젝트 받아오기
                    IconList[i] = Contents.transform.GetChild(i).gameObject;
                    GameObject IconImage = IconList[i].transform.GetChild(3).gameObject;
                    //MapList의 이미지 컴포넌트를 받아오기
                    if (IconImage.tag == "MAPICON")
                    {
                        IconImage.GetComponent<Image>().sprite = IconSourceList[i];
                    }
                    //자식의 여러 tag 확인하기
                    //GameObject[] childObject = GameObject.FindGameObjectsWithTag("MAPIMG");
                }
            }




        }
}
