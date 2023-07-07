using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMove : MonoBehaviour
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

        if      (Input.GetKeyDown(KeyCode.RightArrow))   StartCoroutine(Rolling(Vector3.right));
        else if (Input.GetKeyDown(KeyCode.LeftArrow))    StartCoroutine(Rolling(Vector3.left));
        else if (Input.GetKeyDown(KeyCode.UpArrow))      StartCoroutine(Rolling(Vector3.forward));
        else if (Input.GetKeyDown(KeyCode.DownArrow))    StartCoroutine(Rolling(Vector3.back));
    }



    private IEnumerator Rolling(Vector3 dir)
    {
        
        isMove = true;

        // 큐브 회전 각도
        float angle = 90;
        Vector3 center, axis;

        // 큐브 회전 중심 좌표
        // (현재 위치) + (회전방향/2)*큐브의 스케일 + (회전축/2)*큐브의 스케일
        // (현재 위치) + (회전축x,z좌표)           + (회전축y좌표)
        center = transform.position + (dir / 2) * transform.localScale.x + (Vector3.down / 2) * transform.localScale.x;
        
        // 큐브 회전 축 
        // 두 벡터의 교차점에 수직 벡터 생성
        axis = Vector3.Cross(Vector3.up, dir);

        while (angle > 0)
        {
            if(TempDetect.doubleMove == DoubleMoveState.Moving) 
            {
                Debug.Log("STOP");
                break;
            }
            float rotationAngle = Time.deltaTime * speed;
            transform.RotateAround(center, axis, rotationAngle);
            angle -= rotationAngle;
            yield return null;
        }

        if(TempDetect.doubleMove == DoubleMoveState.Moving)
        {
             angle += 90;
            // center = transform.position + (dir / 2) * transform.localScale.x + (Vector3.down / 2) * transform.localScale.x;
            // axis = Vector3.Cross(Vector3.up, dir);
            // transform.RotateAround(center, axis, angle);
            // Debug.Log("Detect!!, Around!");
            center = transform.position + (Vector3.down / 2) * transform.localScale.x / 2f;// + (dir / 2);
        
            // 큐브 회전 축 
            // 두 벡터의 교차점에 수직 벡터 생성
            axis = Vector3.Cross(Vector3.up, dir);
            while (angle > 0)
            {
                Debug.Log("gO");
                float rotationAngle = Time.deltaTime * speed;
                transform.RotateAround(center, axis, rotationAngle);
                angle -= rotationAngle;
                yield return null;
            }
            TempDetect.doubleMove = DoubleMoveState.On;
            
        }
        // transform.RotateAround(center, axis, angle);


        // 위치보정
        Vector3 pos = this.transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = TempDetect.doubleMove == DoubleMoveState.On ? 7.15f : 6.65f;
        //pos.y = 6.65f;
        pos.z = Mathf.Round(pos.z);

        //this.transform.position = pos;
        // Quaternion rot = this.transform.localRotation;
        // //rot.x = rot.x / 90;
        // rot.x -= rot.x % 90;
        // rot.y -= rot.y % 90;
        // rot.z -= rot.z % 90;
        // rot.w -= rot.w % 90;
        
        // this.transform.rotation = rot;



        isMove = false;
        yield return null;
    }

}