using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;

public class TM : MonoBehaviour
{
    float curTime;
    int angle;

    private void Update() 
    {
        curTime += Time.deltaTime;

        if(curTime > 1.5)
        {
            angle += 90;
            transform.DORotate(new Vector3(angle, 0, 0), 1);
            curTime = 0;
        }
    }
}
