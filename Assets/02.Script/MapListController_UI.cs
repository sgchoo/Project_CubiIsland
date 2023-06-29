using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapListController_UI : MonoBehaviour
{
    [Header("Content 직접 연결")]
    public GameObject Contents;

    [Header("맵 이미지 소스, 직접 연결")]
    public Sprite[] MapSourceList;

    [Header("맵 아이콘 소스, 직접 연결")]
    public Sprite[] IconSourceList;

    [Header ("맵 프리팹, 직접 연결")]
    public GameObject[] MapPrefabs;

    // 연결된 Content의 자식 갯수
    private int ContentNum;

    // 맵 이미지 리스트
    private GameObject[] MapList;

    // 맵 아이콘 리스트
    private GameObject[] IconList;

    [Header("선택 된 맵")]
    public static GameObject CurrentMap;

    void Start()
    {
        CurrentMap = UIController2_UI.FinalMap;
        SetMapList_Image();
        SetIconList_Image();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIController2_UI.FinalMap == null)
        {
            Debug.Log("Update : UI프리팹 소실");
        }
    }


    public void btnFinalMap()
    {
        // <리스트에 커진 객체를 UI_FinalMap에 프리팹으로 저장하기>
        // 1. Swipe_UI의 CurrentMap(GameObject)값 받아오기
        // 2. Map03이면, 프리팹 객체 리소스 ("") / 6개 만들기
        // 3. 프리팹 오브젝트를 FinalMap,CurrentMap에 할당
        CurrentMap = swipe_UI.CurrentMap;
        if(CurrentMap.name == "Map01"){CurrentMap = MapPrefabs[0];}
        if(CurrentMap.name == "Map02"){CurrentMap = MapPrefabs[1];}
        if(CurrentMap.name == "Map03"){CurrentMap = MapPrefabs[2];}
        if(CurrentMap.name == "Map04"){CurrentMap = MapPrefabs[3];}
        if(CurrentMap.name == "Map05"){CurrentMap = MapPrefabs[4];}
        if(CurrentMap.name == "Map06"){CurrentMap = MapPrefabs[5];}

        UIController2_UI.FinalMap = CurrentMap;
        Debug.Log("현재 선택한 맵 : " + CurrentMap.name);
        Debug.Log("FinalMap : " + UIController2_UI.FinalMap.name);

        SceneManager.LoadScene("04.PlazaScene");

    }


    // 맵 이미지, 아이콘 바꾸기 
    // (굳이 이렇게 안하고 직접 오브젝트의 이미지소스를 바꿔도 되지만..)
    private void SetMapList_Image()
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
    private void SetIconList_Image()
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
