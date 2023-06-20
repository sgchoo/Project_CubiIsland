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
    //굴러가는 이동 값 체크

    void Update()
    {
        Move();
        ChangeRotate();
    }

    // forward이동 및 로테이션 고정 함수
    void Move()
    {
        // 앞으로 이동
        this.transform.position += transform.forward * moveSpeed * Time.deltaTime; 
    }


    //플레이어 회전 함수
    private void ChangeRotate()
    {
        RaycastHit hitInfo;

        Vector3 rayDirection = ((-transform.up) + (-transform.forward)).normalized;

        // local포지션의 방향으로 레이 발사.
        Ray ray = new Ray(transform.position, rayDirection);

        if(Physics.Raycast(ray, out hitInfo, 5f))
        {
            Debug.Log(hitInfo.transform.name);
        
            // 내 현재 방향에서 hitInfo.normal(법선벡터) 방향으로 회전
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.FromToRotation(Vector3.up, hitInfo.normal), 1f);
        }
    }
}
