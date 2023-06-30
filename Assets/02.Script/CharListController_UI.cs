// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class CharListController : MonoBehaviour
// {
//     //프리팹 연결하기
//     //배열로 바꿔서 저장하기
//     public GameObject CharPos;
//     private GameObject CurrentChar; 

//     public GameObject[] Contents;

//     // GameObject 배열 만들기
//     public GameObject[] CharPrefabs;


//     // Start is called before the first frame update
//     void Start()
//     {
//         CurrentChar = UIController2_UI.FinalChar;
//         //새 객체 생성하기
//         GameObject newObject = Instantiate(CharPrefabs[9]) as GameObject;
//         //부모 하위에 위치하기
//         newObject.transform.SetParent(CharPos.transform, false);
//         //이전 객체를 새 객체로 바꿔주기
//         CurrentChar = newObject;
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     public void CharList_00()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Bear");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[0]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_01()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Bull");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[1]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_02()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Deer");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[2]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_03()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Horse");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[3]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_04()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Leopard");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[4]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_05()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Lion");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[5]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_06()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Mouse");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[6]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_07()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Panda");

//         // CurrentChar 지우기
//         Destroy(CurrentChar);

//         GameObject newObject = Instantiate(CharPrefabs[7]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_08()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Pig");
//         // CurrentChar 지우기
//         Destroy(CurrentChar);
//         GameObject newObject = Instantiate(CharPrefabs[8]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_09()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Polarbear");
//         // CurrentChar 지우기
//         Destroy(CurrentChar);
//         GameObject newObject = Instantiate(CharPrefabs[9]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_10()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("Rabbit");
//         // CurrentChar 지우기
//         Destroy(CurrentChar);
//         GameObject newObject = Instantiate(CharPrefabs[10]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
//     public void CharList_11()
//     {
//         // 버튼 클릭 시 프리팹 변경
//         Debug.Log("wolf");
//         // CurrentChar 지우기
//         Destroy(CurrentChar);
//         GameObject newObject = Instantiate(CharPrefabs[11]) as GameObject;
//         newObject.transform.SetParent(CharPos.transform, false);
//         CurrentChar = newObject;
//     }
    

// }
