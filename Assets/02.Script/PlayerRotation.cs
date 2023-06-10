using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // 구르는 속도, 최저 300으로 설정할 것(그게 제일 자연스러웠음)
    [SerializeField] int rollSpeed = 3;

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

        Assemble(Vector3.forward);

        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Rolling(anchor, axis));
        }

        Debug.Log(Physics.gravity);
    }
    private IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        
        isMove = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMove = false;
    }

    private void OnCollisionEnter(Collision other) 
    {
             if(other.collider.CompareTag("Side1")) Physics.gravity = Vector3.down * 9.8f;
        //else if(other.collider.CompareTag("Side2")) Physics.gravity = Vector3.left * 9.8f;
        //else if(other.collider.CompareTag("Side3")) Physics.gravity = Vector3.back * 9.8f;
        else if(other.collider.CompareTag("Side4")) Physics.gravity = Vector3.back * 9.8f;
        //else if(other.collider.CompareTag("Side5")) Physics.gravity = Vector3.up * -9.8f;
        //else if(other.collider.CompareTag("Side6")) Physics.gravity = Vector3.forward * -9.8f;
    }
}
