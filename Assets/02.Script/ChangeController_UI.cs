using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeController_UI : MonoBehaviour

{
    [Header("프리팹 생성 위치")]
    public GameObject Char_05;

    [Header("선택 된 캐릭터")]
    public static GameObject CurrentChar;
    private GameObject selectedObject;      // 선택한 캐릭터 오브젝트 담을 변수
    [Header("선택 된 캐릭터 이름")]
    public TMP_Text tmpText;                // 선택한 캐릭터 오브젝트 이름 Text 출력변수

    [Header("캐릭터 리스트, 직접 연결")]
    public GameObject[] Contents;

    [Header("캐릭터 프리팹, 직접 연결")]
    public GameObject[] CharPrefabs;

    private int selectedIndex;

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
            Debug.Log("Update : UI프리팹 소실");
        }

        ChooseCharacter();
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
            //Char_05 = UIController2_UI.FinalChar;

            Debug.Log("백업 캐릭터" + CurrentChar.name);
            Debug.Log("UIController2_UI.FinalChar" + UIController2_UI.FinalChar.name);
        }
    }


    public void btnFinalChar()
    {
        // Preview창의 캐릭터 최종 선택 / 누르지 않고 뒤로가면 저장되지 않음
        GameObject selectedPrefab = CharPrefabs[selectedIndex];
        // FinalChar에 선택한 프리팹 할당
        UIController2_UI.FinalChar = selectedPrefab;

        Debug.Log("최종 캐릭터 : " + UIController2_UI.FinalChar.name);

        //UIController_UI.FianlChar 선택 백업
        CurrentChar = selectedPrefab;
        GameData.Instance.currentCharacter = selectedPrefab;
        PlayAssetManager.isSet = false;

        SceneManager.LoadScene("04.PlazaScene");
    }

    // 버튼 하나씩 메서드 만들기 싫어서 만든 코드
    public void ButtonClicked(GameObject clickedBtn)
    {
        // 클릭된 버튼의 부모로부터 Content의 참조 얻기
        Transform Contents = clickedBtn.transform.parent;

        // Content의 자식들을 순회하며 클릭된 버튼 찾기
        for (int i = 0; i < Contents.childCount; i++)
        {
            Transform child = Contents.GetChild(i);
            if (child.gameObject == clickedBtn)
            {
                // 일치하는 버튼을 찾았을 때 인덱스 기록
                selectedIndex = i;
                break;

            }
        }
        CharChange();

    }

    public void CharChange()
    {
        Destroy(CurrentChar);
        GameObject newObject = Instantiate(CharPrefabs[selectedIndex]) as GameObject;
        newObject.transform.SetParent(Char_05.transform, false);
        CurrentChar = newObject;
    }

    //캐릭터 선택 시 오브젝트 이름 가져오는 함수
    private void ChooseCharacter()
    {
        //EventSystem 클래스 내 현재 선택된(클릭한) 오브젝트를 가져와서 변수에 저장한다.
        selectedObject = EventSystem.current.currentSelectedGameObject;
        tmpText.text = "" + selectedObject.name;

        Debug.Log(selectedObject.name);
    }
}
