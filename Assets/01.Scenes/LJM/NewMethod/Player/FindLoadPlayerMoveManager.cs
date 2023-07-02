using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindLoadPlayerMoveManager : MonoBehaviour
{
    public Transform[] roller;
    public float rotateSpeed;
    private Transform parent;
    private bool isRolling = false;

    private List<Transform> childList;

    public Transform axisObject;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent;
        childList = new List<Transform>();
        foreach(Transform child in parent)
        {   
            if(child == this.transform || child == axisObject) continue;
            childList.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isRolling) return;
        if      (Input.GetKeyDown(KeyCode.UpArrow))     StartCoroutine(Rolling(Vector3.forward));
        else if (Input.GetKeyDown(KeyCode.RightArrow))  StartCoroutine(Rolling(Vector3.right));
        else if (Input.GetKeyDown(KeyCode.DownArrow))   StartCoroutine(Rolling(Vector3.down));
        else if (Input.GetKeyDown(KeyCode.LeftArrow))   StartCoroutine(Rolling(Vector3.left));
    }

    private IEnumerator Rolling(Vector3 dir)
    {
        isRolling = true;

        float angle = 90f;

        int idx = -1;
        if      (dir == Vector3.forward){ idx = 0; }
        else if (dir == Vector3.right)  { idx = 1; }
        else if (dir == Vector3.down)   { idx = 2; }
        else if (dir == Vector3.left)   { idx = 3; }

        // 회전 타겟 지정
        Transform rotateTarget = roller[idx];

        yield return null;
        if(!rotateTarget.GetComponent<CollisionCheck>().collide)
        {
            // 이전 회전정보 저장
            Quaternion prevRot = rotateTarget.localRotation;

            // 회전축에 player 넣기
            this.transform.parent = rotateTarget;

            while (angle > 0)
            {
                float rotateAngle = Time.deltaTime * rotateSpeed;
                if(rotateAngle >= angle) rotateAngle = angle;

                rotateTarget.Rotate(Vector3.right, rotateAngle, Space.Self);
                angle -= rotateAngle;
                yield return null;
            }

            // Player 부모 초기화
            this.transform.parent = parent;

            // 회전타겟 회전 정상화
            rotateTarget.rotation = prevRot;  

            SetAxis(prevRot);
        }
        else
        {
            Debug.Log("막힘");
        }

        isRolling = false;
    }

    private void SetAxis(Quaternion prevRot)
    {
        // 회전축을 전부 axisObject에 넣기
        foreach(Transform child in childList) { child.parent = axisObject; }
        // axisObject를 player 위치로 이동
        axisObject.localPosition = this.transform.localPosition;
        // 회전축들의 parent를 parentObject로 변경
        foreach(Transform child in childList) { child.parent = parent; }
    }
}
