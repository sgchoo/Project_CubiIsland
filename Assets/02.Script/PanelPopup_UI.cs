using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PanelPopup_UI : MonoBehaviour
{
    public GameObject PanelGame;

    // Start is called before the first frame update
    void Start()
    {
        if(PanelGame.gameObject != null)
        {PanelGame.SetActive(false);}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 튜토리얼 안볼거야? 창 열기
    public void btnPopupOn()
    {
        PanelGame.SetActive(true);
    }

    public void btnPopupOff()
    {
        PanelGame.SetActive(false);
    }

    public void btnStartCheck() { SceneMove(KeyStore.startCheckScene); }
    public void btnCreatePlaza() { SceneMove(KeyStore.createPlazaScene); }

    // 씬 이동 로직
    private void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 패널 바깥영역 터치하면 패널 꺼지도록 하기 (옵션창, 큐브체크패널 등)
    public void OnPointerClick(PointerEventData eventData)
    {
        print("터치");
        if (eventData.pointerCurrentRaycast.gameObject != gameObject)
        {
            PanelGame.SetActive(false);
        }
    }
    
}
