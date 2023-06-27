using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeController_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 임시로 버튼 누르면 씬 로드하게 넣어놨음

    public void btnTempChar(){ SceneManager.LoadScene("05.ChangeCharScene");}
    public void btnTmepMap(){ SceneManager.LoadScene("06.ChangeMapScene");}

    // Ray 오브젝트 충돌 감지, 터치 시 씬 로드하기
    

}
