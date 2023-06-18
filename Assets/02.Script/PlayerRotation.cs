using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // 구르는 속도, 최저 300으로 설정할 것(그게 제일 자연스러웠음)
    public int speed = 400;

    public Transform tr;

    // 움직임 상태를 표현하는 변수
    bool isMove = false;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // 움직이지 않는 상태라면, 방향키를 입력받아 그 방향으로 굴리기 
    // 움직이는 상태라면, update를 중단하기
    void Update()
    {
        if(isMove)return;

        // if      (rb.velocity.x > 0)   StartCoroutine(Rolling(Vector3.right));
        // else if (rb.velocity.x < 0)    StartCoroutine(Rolling(Vector3.left));
        // else if (rb.velocity.z > 0)      StartCoroutine(Rolling(Vector3.forward));
        // else if (rb.velocity.z < 0)    StartCoroutine(Rolling(Vector3.back));
        StartCoroutine(Rolling(Vector3.left));

        Physics.gravity = Vector3.Cross(this.transform.position, tr.position) * -9.8f;

        Debug.Log(Vector3.Cross(this.transform.position, tr.position));
    }

    private IEnumerator Rolling(Vector3 dir)
    {
        
        isMove = true;

        // 큐브 회전 각도
        float angle = 90;

        // 큐브 회전 중심 좌표
        // (현재 위치) + (회전방향/2)*큐브의 스케일 + (회전축/2)*큐브의 스케일
        // (현재 위치) + (회전축x,z좌표)           + (회전축y좌표)
        Vector3 center = transform.position + (dir / 2) * transform.localScale.x + (Vector3.down / 2) * transform.localScale.x;
        
        // 큐브 회전 축 
        // 두 벡터의 교차점에 수직 벡터 생성
        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        // angle이 0보다 큰 동안 주어진 (회전중심점, 회전축)을 기준으로 회전각도만큼 회전시키기
        // 회전 후 angle값은 회전한 값만큼 빼서 회전 각도 업데이트
        // 다음 프레임까지 잠시 대기한 후 angle이 0이 될 때까지 회전 업데이트
        while (angle > 0)
        {
            float rotationAngle = Time.deltaTime * speed;
            transform.RotateAround(center, axis, rotationAngle);
            angle -= rotationAngle;
            yield return null;
        }

        isMove = false;
    }
}
