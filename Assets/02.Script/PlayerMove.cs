using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<summary>
// 플레이어 cube는 앞으로만 이동
// ray를 쏴서 Edge와의 거리를 계산 후
// 큐브 다음 면으로 넘어가기
//</summary>


public class PlayerMove : MonoBehaviour
{
    //이동 속도
    public float moveSpeed = 0.01f;
    private Vector3 currentDir = Vector3.forward;
    private Vector3 localScale = Vector3.zero;
    private bool isMove = false;
    private struct Coords
    {
        public int x;
        public int y;

        public Coords(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }

    private Coords coords = new Coords(2,1);


    void Update()
    {
        Move();
    }

    // forward이동 및 로테이션 고정 함수
    void Move()
    {
        // 앞으로 이동
        Debug.Log("This Transform Position : " + transform.position);
        Debug.Log("This Transform Local Position : " + transform.position);
        if(isMove)return;
        StartCoroutine(Rolling(currentDir));
    }
    
    private IEnumerator Rolling(Vector3 dir)
    {
        
        isMove = true;
        float angle = 90;
        
        
        Debug.Log("실행은 되고 있니");
       
        Debug.Log(GetCurrentPos());
        Vector3 center = GetCurrentPos() + (dir / 2) * 0.01f + (ConvertVectorDown(dir) / 2) * 0.01f;        
        Debug.Log(center);
        Vector3 axis = Vector3.Cross(ConvertVectorUp(currentDir), dir);
        Debug.Log(axis);
        while (angle > 0)
        {
            float rotationAngle = Time.deltaTime * moveSpeed;
            if(rotationAngle >= angle) rotationAngle = angle;
            transform.RotateAround(center, axis, rotationAngle);            
            angle -= rotationAngle;
            yield return null;
        }

        coords.y += 1;

        if(coords.y > 4) 
        {
            coords.y = 0;
            angle = 90;
            
            center = GetCurrentPos() + (- dir / 2) * 0.01f + (ConvertVectorDown(dir) / 2) * 0.01f;        
            axis = Vector3.Cross(ConvertVectorUp(currentDir), dir);

            while (angle > 0)
            {
                float rotationAngle = Time.deltaTime * moveSpeed;
                if(rotationAngle >= angle) rotationAngle = angle;
                transform.RotateAround(center, axis, rotationAngle);            
                angle -= rotationAngle;
                yield return null;
            }

            currentDir = ConvertVectorDown(currentDir);
        }
        isMove = false;
    }
    
    public Vector3 ConvertVectorDown(Vector3 input)
    {
        if (input == Vector3.forward)
        {
            return Vector3.down;
        }
        else if (input == Vector3.down)
        {
            return Vector3.back;
        }
        else if (input == Vector3.back)
        {
            return Vector3.up;
        }
        else if (input == Vector3.up)
        {
            return Vector3.forward;
        }
        else
        {
            return input; // 변환할 수 없는 경우 입력값 그대로 반환
        }
    }

    public Vector3 ConvertVectorUp(Vector3 input)
    {
        if (input == Vector3.forward)
        {
            return Vector3.up;
        }
        else if (input == Vector3.down)
        {
            return Vector3.forward;
        }
        else if (input == Vector3.back)
        {
            return Vector3.down;
        }
        else if (input == Vector3.up)
        {
            return Vector3.back;
        }
        else
        {
            return input; // 변환할 수 없는 경우 입력값 그대로 반환
        }
    }

    private Vector3 GetCurrentPos()
    {
        if(this.transform.parent == null)
        {
            Debug.Log("실행은 되고 있는거니");
            return this.transform.position;
        }
        else 
        {
            Debug.Log("실행은 안되고있는거니");
            return this.transform.localPosition;
        }
    }
}
