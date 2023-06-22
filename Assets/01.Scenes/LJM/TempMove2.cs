using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TempMove2 : MonoBehaviour
{
    // feature
    // 1. 앞으로만 전진함
    // 2. 끝쪽에 닿으면 90도를 더 회전해야 한다.
    // 3. 현실 큐브 방향을 특정이상 틀면 회전한다.

    // Logic
    // p-1) 회전할 축 정보를 rotateAxis 변수에 받아온다.
    public Transform rotateAxis;

    // p-2) 큐브의 현재 부모 객체 정보를 parent 변수에 받아온다.
    public Transform parent;

    // p-3) rotateAxis의 현재 회전각 정보를 저장할 변수 rotateAngle를 만든다.
    private Quaternion rotateAngle;

    // p-4) 큐브를 회전시킬 각도 정보를 angle 변수에 저장한다.(90도)
    private float angle = 90f;

    // p-5) 회전 속도
    private float rotateSpeed = 15f;

    // p-6) 큐브가 몇 칸 이동했는지 저장할 구조체(Coords) 변수 coords를 만든다.
    // p-6-1) coords는 int값으로 x(가로칸), y(세로칸)를 저장한다.
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
    private Coords coords;   

    private void Start() 
    {
        coords = new Coords(2,1);
    }

    private void Update() 
    {
        // e-0) parent의 방향을 연산하여 큐브의 회전 방향을 지정한다...

        // e-1) 큐브를 rotateAxis의 자식 객체로 저장한다.
        this.transform.parent = rotateAxis;
        // e-3) rotateAxis의 회전각 정보를 rotateAngle에 저장해둔다.
        rotateAngle = rotateAxis.rotation;
        // e-2) rotateAxis를 angle변수의 값만큼 회전시킨다.
        float x = 0f, y = 0f, z = 0f;
        Quaternion targetRotation = Quaternion.Euler(x, y, z);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotateAxis.rotation, rotateSpeed);

        // e-2-1) 회전 각도가 90도와 유사한지 검사하기
        if (Quaternion.Angle(this.transform.rotation, targetRotation) < 0.1f)
        {
            // 회전을 멈추고 정확히 90도로 설정
            this.transform.rotation = targetRotation;
        }
        // e-3) 큐브를 parent의 자식 객체로 저장한다.
        this.transform.parent = parent;
        // e-4) rotateAxis의 회전각 정보를 rotateAngle로 초기화한다.
        rotateAxis.rotation = rotateAngle;
        // e-5) rotateAxis를 이동한 방향으로 큐브의 localScale.x만큼 이동시킨다.
        //rotateAxis.position
        // e-6) 이동한 방향의 coords 멤버 값을 1 연산한다.

        // e-7) 만약 이동한 방향의 coords의 값이 4보다 높거나, 0보다 작다면
        // e-7-1) coords의 해당 멤버를 -1 또는 5로 설정한다.
        // e-7-2) angle값을 90 또는 -90으로 설정한다.
        // e-7-3) 그렇지 않다면,
        // e-7-4) angle값을 90으로 초기화한다.
        if (coords.x > 4)
        { 
            return;
        }
        else if (coords.x < 0)
        { 
            return;
        }
        else if (coords.y > 4) 
        {
            return;
        }
        else if (coords.y < 0) 
        {
            return;
        }
        else 
        {
            angle = 90;
        }
        
    }

}
