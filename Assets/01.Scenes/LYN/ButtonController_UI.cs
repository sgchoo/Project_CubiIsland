using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController_UI : MonoBehaviour
{
    //프리팹 연결하기
    //배열로 바꿔서 저장하기
    public GameObject CharPos;
    public GameObject CurrentObject; // 바꿀 오브젝트

    public GameObject[] Contents;

    // GameOnject 배열 만들기
    public GameObject[] CharPrefabs;

    




    // Start is called before the first frame update
    void Start()
    {
        //새 객체 생성하기
        GameObject newObject = Instantiate(CharPrefabs[9]) as GameObject;
        //부모 하위에 위치하기
        newObject.transform.SetParent(CharPos.transform, false);
        //이전 객체를 새 객체로 바꿔주기
        CurrentObject = newObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBtnClick_00()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[0]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }

    public void OnBtnClick_01()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[1]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }

    public void OnBtnClick_02()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[2]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }
    public void OnBtnClick_03()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[3]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }
    public void OnBtnClick_04()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[4]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }
    public void OnBtnClick_05()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[5]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }
    public void OnBtnClick_06()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[6]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }
    public void OnBtnClick_07()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[7]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }
    public void OnBtnClick_08()
    {
        // 버튼 클릭 시 프리팹 변경
        Debug.Log("Bear");

        // CurrentObject 지우기
        Destroy(CurrentObject);

        GameObject newObject = Instantiate(CharPrefabs[8]) as GameObject;
        newObject.transform.SetParent(CharPos.transform, false);
        CurrentObject = newObject;
    }


}
