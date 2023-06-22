using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    float curTime;
    float angle;

    private void Update() 
    {
        MoveEvent();
    }

    void MoveEvent()
    {
        curTime += Time.deltaTime;

        if(curTime > 1.5f)
        {
            angle += 90.0f;
            transform.DOMove(Vector3.forward * 0.01f, 1.0f).SetRelative();
            transform.DORotate(new Vector3(angle, 0, 0), 1.0f).SetEase(Ease.Unset);
            curTime = 0;
        }
    }
}
