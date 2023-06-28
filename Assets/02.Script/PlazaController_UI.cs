using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlazaController_UI : MonoBehaviour
{
    public GameObject Char_04;
    public GameObject Map_04;

    private GameObject PreviewChar;




    void Start()
    {
        Debug.Log("4번씬");
        SetChar();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChar()
    {
        if (UIController2_UI.FinalChar == null)
        {
            Debug.Log("UI프리팹 소실, Plaza 데이터로 대체");
            GameObject newObject = Instantiate(ChangeController_UI.CurrentChar) as GameObject;
            newObject.transform.SetParent(Char_04.transform, false);
            PreviewChar = newObject;
        }
        else
        { 
            Debug.Log("UI컨트롤러 프리팹임");
            GameObject newObject = Instantiate(UIController2_UI.FinalChar) as GameObject;
            newObject.transform.SetParent(Char_04.transform, false);
            PreviewChar = newObject;
        }

    }
    // public void SetMap()
    // {
    //     if (UIController2_UI.FinalMap == null)
    //     {
    //         Debug.Log("UI프리팹 소실");
    //     }
    //     else
    //     { 
    //         Debug.Log("UI컨트롤러 프리팹임");
    //         GameObject newObject = Instantiate(UIController2_UI.FinalMap) as GameObject;
    //         newObject.transform.SetParent(Char_04.transform, false);
    //         PreviewChar = newObject;
    //     }
    // }

    // 임시로 버튼 누르면 씬 로드하게 넣어놨음 -> 오브젝트 충돌 시 넘어가도록 수정 요망
    public void btnTempChar() { SceneManager.LoadScene("05.ChangeCharScene");}
    public void btnTempMap() { SceneManager.LoadScene("05.ChangeCharScene");}

}
