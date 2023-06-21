using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<Summary>
///방향키에 따라 큐브 굴리기
///</Summary>
public class TempMove1 : MonoBehaviour
{
    // 구르는 속도, 최저 300으로 설정할 것(그게 제일 자연스러웠음)
    public int speed = 400;

    // 움직임 상태를 표현하는 변수
    bool isMove = false;

    // 움직이지 않는 상태라면, 방향키를 입력받아 그 방향으로 굴리기 
    // 움직이는 상태라면, update를 중단하기
    void Update()
    {
        if(isMove)return;

        if      (Input.GetKey(KeyCode.RightArrow))   StartCoroutine(Rolling(Vector3.right));
        else if (Input.GetKey(KeyCode.LeftArrow))    StartCoroutine(Rolling(Vector3.left));
        else if (Input.GetKey(KeyCode.UpArrow))      StartCoroutine(Rolling(Vector3.forward));
        else if (Input.GetKey(KeyCode.DownArrow))    StartCoroutine(Rolling(Vector3.back));
    }

    private IEnumerator Rolling(Vector3 dir)
    {
        
        isMove = true;

        // 큐브 회전 각도
        float angle = 90;
        Vector3 center, axis;
        center = transform.position + (dir / 2) * transform.localScale.x + (Vector3.down / 2) * transform.localScale.x;
        axis = Vector3.Cross(Vector3.up, dir);

        while (angle > 0)
        {
            float rotationAngle = Time.deltaTime * speed;
            if(rotationAngle >= angle) rotationAngle = angle;
            transform.RotateAround(center, axis, rotationAngle);
            angle -= rotationAngle;
            yield return null;
        }
        
        isMove = false;
        yield return null;
    }

}
