using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

// <Summary>
// 플레이어가 Cube위를 지속적으로 걸어다님
// 현재 앞방향만 구현
// </Summary>

public class PlayerAutoMove : MonoBehaviour
{
    private void Update() 
    {        
        transform.Translate(Vector3.forward * Time.deltaTime * 3, Space.Self);
        Vector3 dir = GetComponent<ParentConstraint>().GetTranslationOffset(0);
        GetComponent<ParentConstraint>().SetTranslationOffset(0, Vector3.forward * Time.deltaTime * 3);
        //새로운 중력 값 적용
        //Physics.gravity = -transform.up * 9.8f;

        //ChangeRotate();
    }

    //플레이어 회전 함수
    private void ChangeRotate()
    {
        RaycastHit hitInfo;

        Vector3 rayDirection = ((-transform.forward) + (-transform.up)).normalized;

        // local포지션의 방향으로 레이 발사.
        Ray ray = new Ray(transform.localPosition, rayDirection);

        
        if(Physics.Raycast(ray, out hitInfo, 5.0f))
        {
            // 내 현재 방향에서 hitInfo.normal(법선벡터) 방향으로 회전
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, hitInfo.normal), 0.03f);
        }
    }
}
