using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTension : MonoBehaviour
{
    private Vector3 prevScale;

    float ytime;
    float xtime;
    float y = 0f;
    float x = 0f;

    private void Start() 
    {
        prevScale = this.transform.localScale;    
        ytime = 0;
        xtime = 0;
    }

    private void Update()
    {
        // bool flag = false;
        // if(SceneManager.GetActiveScene().name == KeyStore.findKeyScene)
        // {
        //     flag = FindKeyPlayerMoveManager.isTensionActive;
        // }
        // else 
        // {
        //     flag = FindLoadPlayerMoveManager2.isTensionActive;
        // }
        
        // if(flag)
        // {
        //     // Player의 Tension 시작
        //     ytime += Time.deltaTime;
        //     if      (ytime < 0.4f)   { y += 0.005f;   if (y > 1f)     y = 1f;  }
        //     else if (ytime < 0.8f)   { y -= 0.005f;   if (y < 0.7f)   y = 0.7f;}
        //     else                    { ytime = 0f; }

        //     if      (xtime < 0.4f)   { x -= 0.005f;   if (x < 0.7f)  x = 0.7f;  }
        //     else if (xtime < 0.8f)   { x += 0.005f;   if (x > 1f)    x = 1f;}
        //     else                    { xtime = 0f; }
        //     this.transform.localScale = new Vector3(y, y, y);
        // }
        // else
        // {
        //     // Player의 Tension 종료, 사이즈 원상복구
        //     //this.transform.localScale = prevScale;
        //     ytime = 0f;
        //     xtime = 0;
        // }
    }
}
