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
        SetMapList_Image();
        SetIconList_Image();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.currentWorld == null)
        {
            Debug.Log("Update : UI프리팹 소실");
        }
    }


    public void btnFinalMap()
    {
        // 현재 선택된 맵 가져오기
        CurrentMap = swipe_UI.CurrentMap;

        // 현재 선택된 맵의 이름 저장
        string currentMapName = CurrentMap.name;

        foreach (GameObject prefab in MapPrefabs)
        {
            if (prefab.name == currentMapName)
            {
                GameData.Instance.currentWorld = prefab; // 맵 프리팹을 UIController_UI.FinalMap에 저장
                break;
            }
        }
        PlayAssetManager.isSet = false;
    }

    // 맵 이미지, 아이콘 이미지 바꾸기 메인 기능
    private void Settings(ref GameObject[] list, int childIdx, string currentTag, Sprite[] sourceList)
    {
        if (Contents == null) { Debug.Log("Contents 오브젝트를 찾을 수 없습니다."); }
        else
        {
             // Content 자식의 갯수로 배열 만들기
            ContentNum = Contents.transform.childCount;
            //MapList 객체 받아오기
            list = new GameObject[ContentNum];

            for (int i = 0; i < ContentNum; i++)
            {
                //Content의 순서대로 MapList오브젝트 받아오기
                list[i] = Contents.transform.GetChild(i).gameObject;
                GameObject img = list[i].transform.GetChild(childIdx).gameObject;
                //MapList의 이미지 컴포넌트를 받아오기
                if (img.tag == currentTag)
                {
                    img.GetComponent<Image>().sprite = sourceList[i];
                }
            }
        }
    }

    // 맵 이미지, 아이콘 바꾸기 
    // (굳이 이렇게 안하고 직접 오브젝트의 이미지소스를 바꿔도 되지만..)
    private void SetMapList_Image()
    {
        Settings(ref MapList, 0, "MAPIMG", MapSourceList);
        // //컨텐츠 연결이 해제 된 경우
        // if (Contents == null) { Debug.Log("Contents 오브젝트를 찾을 수 없습니다."); }
        // else
        // {
            
        //     // Content 자식의 갯수로 배열 만들기
        //     ContentNum = Contents.transform.childCount;

        //     //MapList 객체 받아오기
        //     MapList = new GameObject[ContentNum];

        //     for (int i = 0; i < ContentNum; i++)
        //     {
        //         //Content의 순서대로 MapList오브젝트 받아오기
        //         MapList[i] = Contents.transform.GetChild(i).gameObject;
        //         GameObject IconImage = MapList[i].transform.GetChild(0).gameObject;
        //         //MapList의 이미지 컴포넌트를 받아오기
        //         if (IconImage.tag == "MAPIMG")
        //         {
        //             IconImage.GetComponent<Image>().sprite = MapSourceList[i];
        //         }
        //         //자식의 여러 tag 확인하기
        //         //GameObject[] childObject = GameObject.FindGameObjectsWithTag("MAPIMG");
        //     }
        // }

    }
    private void SetIconList_Image()
    {
        Settings(ref IconList, 3, "MAPICON", IconSourceList);

        // //컨텐츠 연결이 해제 된 경우
        // if (Contents == null) { Debug.Log("Contents 오브젝트를 찾을 수 없습니다."); }

        // else
        // {
        //     // Content 자식의 갯수로 배열 만들기
        //     ContentNum = Contents.transform.childCount;

        //     //MapList 객체 받아오기
        //     IconList = new GameObject[ContentNum];

        //     for (int i = 0; i < ContentNum; i++)
        //     {
        //         //Content의 순서대로 IconList오브젝트 받아오기
        //         IconList[i] = Contents.transform.GetChild(i).gameObject;
        //         GameObject IconImage = IconList[i].transform.GetChild(3).gameObject;
        //         //MapList의 이미지 컴포넌트를 받아오기
        //         if (IconImage.tag == "MAPICON")
        //         {
        //             IconImage.GetComponent<Image>().sprite = IconSourceList[i];
        //         }
        //     }
        // }
    }
}
