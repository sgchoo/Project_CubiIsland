using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChangeController_UI : MonoBehaviour
{
    [SerializeField]
    private CharListController CharListControllerScript;

    [SerializeField]
    private GameObject Char;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 임시로 버튼 누르면 씬 로드하게 넣어놨음
    public void btnTempChar() { SceneManager.LoadScene("05.ChangeCharScene"); }
    public void btnTmepMap() { SceneManager.LoadScene("06.ChangeMapScene"); }

    // Ray 오브젝트 충돌 감지, 터치 시 씬 로드하기

    //if (swipe_UI.CurrentMap.name == "Map01")
    // {
    //     GameObject prefab = Resources.Load<GameObject>("Map01_Grass");
    //     GameObject instantiatedPrefab = Instantiate(prefab);
    //     Debug.Log ("선택한 맵 :" + prefab.name);
    // }



    public void btnFinalChar()
    {
        SetFinalChar();
        Debug.Log("최종 선택" + UIController2_UI.FinalChar);
        SceneManager.LoadScene("04.PlazaScene");
    }
    public void btnFinalMap()
    {
        SetFinalMap();
        Debug.Log("최종 선택" + UIController2_UI.FinalMap);
        SceneManager.LoadScene("04.PlazaScene");
    }
    private void SetFinalMap()
    {
        if (swipe_UI.CurrentMap.name == "Map01")
        {
            GameObject prefab = Resources.Load<GameObject>("Map01_Grass");
            GameObject instantiatedPrefab = Instantiate(prefab);
            Debug.Log("선택한 맵 :" + prefab.name);
        }
        if (swipe_UI.CurrentMap.name == "Map02")
        {
            GameObject prefab = Resources.Load<GameObject>("Map02_Snow");
            GameObject instantiatedPrefab = Instantiate(prefab);
            Debug.Log("선택한 맵 :" + prefab.name);
        }
        if (swipe_UI.CurrentMap.name == "Map03")
        {
            GameObject prefab = Resources.Load<GameObject>("Map03_Desert");
            GameObject instantiatedPrefab = Instantiate(prefab);
            Debug.Log("선택한 맵 :" + prefab.name);
        }
        if (swipe_UI.CurrentMap.name == "Map04")
        {
            GameObject prefab = Resources.Load<GameObject>("Map04_Beach");
            GameObject instantiatedPrefab = Instantiate(prefab);
            Debug.Log("선택한 맵 :" + prefab.name);
        }
        if (swipe_UI.CurrentMap.name == "Map05")
        {
            GameObject prefab = Resources.Load<GameObject>("Map05_City");
            GameObject instantiatedPrefab = Instantiate(prefab);
            Debug.Log("선택한 맵 :" + prefab.name);
        }
        if (swipe_UI.CurrentMap.name == "Map06")
        {
            GameObject prefab = Resources.Load<GameObject>("Map06_PlayGround");
            GameObject instantiatedPrefab = Instantiate(prefab);
            Debug.Log("선택한 맵 :" + prefab.name);
        }
        else
        {
            Debug.LogError("Aprefab을 찾을 수 없습니다.");
        }

    }
    private void SetFinalChar()
    {
        GameObject Temp = gameObject.transform.Find("CharStudio/Char/").gameObject;
        Char = Temp;
    

    }
}
