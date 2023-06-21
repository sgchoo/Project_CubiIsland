using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMove : MonoBehaviour
{
    float curTime;

    private void Update() 
    {
        MoveEvent();
    }

    void MoveEvent()
    {
        curTime += Time.deltaTime;

        if(curTime > 1.5f)
        {
            transform.position += Vector3.forward * Time.deltaTime * 0.01f;
        }
    }
}
