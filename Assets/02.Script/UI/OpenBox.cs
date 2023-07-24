using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// 지정한 depth만큼 기다린 후, 지정한 각도로 회전시키는 코드
/// </Summary>
public class OpenBox : MonoBehaviour
{
    // 전개도가 펼쳐지기 위해 이 스크립트를 가진 오브젝트가 회전하기 위한 각도 좌표
    public Vector3 targetRot;

    // 전개도가 펼쳐지면서 큐브가 조각나는 것을 방지
    public float depth;

    // targetRot을 이용해 구한 회전 각도를 저장할 변수
    private Quaternion target;

    // depth에 따라 회전을 기다릴 초
    private float timer;

    void Start()
    {
        timer = 0f;
        target = Quaternion.Euler(targetRot);
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < depth) return;
        transform.rotation = Quaternion.Lerp(transform.rotation, target, 0.13f);
    }

}
