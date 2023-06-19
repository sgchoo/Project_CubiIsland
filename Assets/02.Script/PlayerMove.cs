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
    //구르는 속도
    public float rollSpeed = 150f;
    //이동 속도
    public float moveSpeed = 2.0f;
    //굴러가는 이동 값 체크
    bool isMove = false;
    //Edge Collider 감지 ray 체크
    bool isBorder;

    Rigidbody rigid;

    private void Start() 
    {
        ComponentInit();
    }

    void Update()
    {
        Move();
        EdgeCheck();
    }

    // 변수 초기화 함수
    void ComponentInit()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // forward이동 및 로테이션 고정 함수
    void Move()
    {
        // 앞으로 이동
        this.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        // player 로컬로테이션 고정
        this.transform.localRotation = Quaternion.Euler(new Vector3(this.transform.localRotation.x, 0.0f, 0.0f));
    }

    //Edge 감지 ray 함수
    void EdgeCheck()
    {
        Ray ray = new Ray(this.transform.position, Vector3.forward);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 10.0f))
        {   
            //hitInfo와 나 사이의 거리와
            //중복 체크 방지용 bool값 조건
            if ((hitInfo.distance < 0.95f) && !isBorder)
            {
                // 이동 속도 0으로 만든 후
                moveSpeed = 0.0f;
                // 큐브 다음면으로 이동
                StartCoroutine(Rolling(Vector3.forward));
            }
        }
    }

    private IEnumerator Rolling(Vector3 dir)
    {
        
        isMove = true;
        //ray 중복 체크 방지
        isBorder = true;

        float angle = 90;

        Vector3 center = transform.position + (dir / 2) * transform.localScale.x + (Vector3.down / 2) * transform.localScale.x;

        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        while (angle > 0)
        {
            float rotationAngle = Time.deltaTime * rollSpeed;
            transform.RotateAround(center, axis, rotationAngle);
            angle -= rotationAngle;
            yield return null;
        }

        // 이동속도 원복
        moveSpeed = 2.0f;
        isMove = false;

        //2초 뒤에 중복 체크 방지용 bool 값 변환
        yield return new WaitForSeconds(2.0f);
        isBorder = false;
    }
}
