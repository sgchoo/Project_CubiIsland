using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChangeController_UI : MonoBehaviour

{   
    public UIController2_UI UIScript;
    public GameObject Char_05;


    public static GameObject CurrentChar;


    public GameObject[] Contents;

    // GameObject 배열 만들기
    public GameObject[] CharPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentChar = UIController2_UI.FinalChar;
        PreviewChar();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIController2_UI.FinalChar == null)
        {
            Debug.Log("UI프리팹 소실");
        }
    }
    
    public void PreviewChar()
    {
        Debug.Log("5번씬 확인");
        if (UIController2_UI.FinalChar == null)
        {
            Debug.Log("UI프리팹 소실");
        }
        else
        { 
            Debug.Log(UIController2_UI.FinalChar.name);
            GameObject newObject = Instantiate(UIController2_UI.FinalChar) as GameObject;
            newObject.transform.SetParent(Char_05.transform, false);
            CurrentChar = newObject;
        }
    }


    public void btnFinalChar()
    {
        //선택한 캐릭터로 최종 캐릭터 변경
        // UIController2_UI.FinalChar = Char_05;
        
        // if(UIController2_UI.FinalChar == null) {print("프리팹 소실");};

        // Debug.Log("최종 선택" + UIController2_UI.FinalChar.name);

        SceneManager.LoadScene("04.PlazaScene");
    }
    // public void btnFinalMap()
    // {
    //     SetFinalMap();
    //     Debug.Log("최종 선택" + UIController2_UI.FinalMap);
    //     SceneManager.LoadScene("04.PlazaScene");
    // }
    //  private void SetFinalMap()
    // {
    //     if (swipe_UI.CurrentMap.name == "Map01")
    //     {
    //         GameObject prefab = Resources.Load<GameObject>("Map01_Grass");
    //         UIController2_UI.FinalChar = Instantiate(prefab);
    //     }
    // if (swipe_UI.CurrentMap.name == "Map02")
    // {
    //     GameObject prefab = Resources.Load<GameObject>("Map02_Snow");
    //     GameObject instantiatedPrefab = Instantiate(prefab);
    //     Debug.Log("선택한 맵 :" + prefab.name);
    // }
    // if (swipe_UI.CurrentMap.name == "Map03")
    // {
    //     GameObject prefab = Resources.Load<GameObject>("Map03_Desert");
    //     GameObject instantiatedPrefab = Instantiate(prefab);
    //     Debug.Log("선택한 맵 :" + prefab.name);
    // }
    // if (swipe_UI.CurrentMap.name == "Map04")
    // {
    //     GameObject prefab = Resources.Load<GameObject>("Map04_Beach");
    //     GameObject instantiatedPrefab = Instantiate(prefab);
    //     Debug.Log("선택한 맵 :" + prefab.name);
    // }
    // if (swipe_UI.CurrentMap.name == "Map05")
    // {
    //     GameObject prefab = Resources.Load<GameObject>("Map05_City");
    //     GameObject instantiatedPrefab = Instantiate(prefab);
    //     Debug.Log("선택한 맵 :" + prefab.name);
    // }
    // if (swipe_UI.CurrentMap.name == "Map06")
    // {
    //     GameObject prefab = Resources.Load<GameObject>("Map06_PlayGround");
    //     GameObject instantiatedPrefab = Instantiate(prefab);
    //     Debug.Log("선택한 맵 :" + prefab.name);
    // }
    //     else
    //     {
    //         Debug.LogError("Aprefab을 찾을 수 없습니다.");
    //     }

    // }



    // public void CharList_00()
    // {
    //     // 버튼 클릭 시 프리팹 변경
    //     Destroy(CurrentChar);
    //     GameObject newObject = Instantiate(CharPrefabs[0]) as GameObject;
    //     newObject.transform.SetParent(Char_05.transform, false);
    //     CurrentChar = newObject; 
    //     Debug.Log("선택 캐릭터 " +CurrentChar.name);
    //     if(UIController2_UI.FinalChar == null) {print("프리팹 소실");};
    // }
    
    public void CharList_00()
    {
        Destroy(CurrentChar);
        GameObject newObject = Instantiate(CharPrefabs[0], Char_05.transform);
        newObject.transform.localPosition = Vector3.zero;
        newObject.transform.localRotation = Quaternion.identity;
    }

}
