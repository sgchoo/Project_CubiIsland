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

    public UIController uIController;

    private int selectedIndex;

    // Start is called before the first frame update
    void Start()
    {
        int count = Contents.Length;
        int lockIdx = GameData.Instance.characterUnLockIdx;
        for(int idx = 0; idx < count; idx++)
        {
            GameObject target = Contents[idx].transform.Find("locked").gameObject;
            if(target.activeSelf)
            {
                if(lockIdx-->0)
                {
                    target.SetActive(false);
                }

                // if(!GameData.Instance.characterLockList[lockIdx].transform.Find("locked").gameObject.activeSelf)
                // {
                //     target.SetActive(false);
                //     GameData.Instance.characterLockList.RemoveAt(lockIdx);
                // }
                // else
                // {
                //     lockIdx+=1;
                // }
            }
        }
        PreviewChar();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentChar == null)
        {
            Debug.Log("Update : UI프리팹 소실");
            return;
        }
    }


    public void PreviewChar()
    {
        GameObject newObject = Instantiate(GameData.Instance.currentCharacter) as GameObject;
        newObject.transform.SetParent(Char_05.transform, false);
        CurrentChar = newObject;
        string compareName = CurrentChar.name.Split("(Clone)")[0];
        Debug.Log("ChangeController::"+compareName);
        int count = CharPrefabs.Length;
        for(int idx = 0; idx < count; idx++)
        {
            if(CharPrefabs[idx].name == compareName)
            {
                tmpText.text = "" + Contents[idx].name;
                break;
            }

        }

    }


    public void btnFinalChar()
    {
        // Preview창의 캐릭터 최종 선택 / 누르지 않고 뒤로가면 저장되지 않음
        GameObject selectedPrefab = CharPrefabs[selectedIndex];
        // FinalChar에 선택한 프리팹 할당
        GameData.Instance.currentCharacter = selectedPrefab;
        PlayerPrefs.SetString(KeyStore.CHARACTER_KEY, selectedPrefab.name);
        PlayerPrefs.Save();
        Debug.Log("B : " + GameData.Instance.currentCharacter.name);
        PlayAssetManager.isSet = false;
    }


    private bool isLock = false;

    // 버튼 하나씩 메서드 만들기 싫어서 만든 코드
    public void ButtonClicked(GameObject clickedBtn)
    {
        // 클릭된 버튼의 부모로부터 Content의 참조 얻기
        Transform Contents = clickedBtn.transform.parent;
        int count = Contents.childCount;
        // Content의 자식들을 순회하며 클릭된 버튼 찾기
        for (int i = 0; i < count; i++)
        {
            Transform child = Contents.GetChild(i);
            if (child.gameObject == clickedBtn)
            {
                if(child.Find("locked").gameObject.activeSelf)
                {
                    isLock = true;
                    break;
                }
                // 일치하는 버튼을 찾았을 때 인덱스 기록
                selectedIndex = i;

                if(CurrentChar!=null && CharPrefabs[selectedIndex].name == CurrentChar.name.Split("(Clone)")[0])
                {
                    btnFinalChar();
                    uIController.btnPlaza();
                }
                break;
            }
        }
        if(!isLock)
        {
            CharChange();
            ChooseCharacter();
        }
        isLock = false;
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
        if(EventSystem.current.currentSelectedGameObject == null) return;
        string checkBtnName = EventSystem.current.currentSelectedGameObject.name;
        if(checkBtnName == "ButtonChoose") return;    
        if(checkBtnName == "ButtonBack") return;    
        if(checkBtnName == "ButtonOption") return;    
        if(checkBtnName == "ToggleRotate") return;    
        //EventSystem 클래스 내 현재 선택된(클릭한) 오브젝트를 가져와서 변수에 저장한다.
        selectedObject = EventSystem.current.currentSelectedGameObject;
        //저장된 변수의 이름을 TMP_Text에 출력한다.
        tmpText.text = "" + checkBtnName;
    }
}
