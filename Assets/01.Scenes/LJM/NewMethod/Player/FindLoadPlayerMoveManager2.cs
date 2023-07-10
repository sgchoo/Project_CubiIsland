using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindLoadPlayerMoveManager2 : MonoBehaviour
{
    public Transform[] roller;
    public float rotateSpeed;
    private Transform parent;
    private bool isRolling = false;

    private List<Transform> childList;

    public Transform axisObject;

    public Button frontBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Button backBtn;

    public void FrontButton()
    {
        if(isRolling) return; 
        StartCoroutine(Rolling(Vector3.forward));
    }
    public void BackButton()
    {
        if(isRolling) return; 
        StartCoroutine(Rolling(Vector3.down));
    }
    public void RightButton()
    {
        if(isRolling) return; 
        StartCoroutine(Rolling(Vector3.right));
    }
    public void LeftButton()
    {
        if(isRolling) return; 
        StartCoroutine(Rolling(Vector3.left));
    }
    void Start()
    {
        // Transform uiTarget = GameObject.Find("Canvas09").transform.Find("PanelSafeArea").transform.Find("Buttons").transform;
        // uiTarget.Find("Front").GetComponent<Button>().onClick.AddListener(FrontButton);
        // uiTarget.Find("right").GetComponent<Button>().onClick.AddListener(RightButton);
        // uiTarget.Find("Back").GetComponent<Button>().onClick.AddListener(BackButton);
        // uiTarget.Find("left").GetComponent<Button>().onClick.AddListener(LeftButton);

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
        Vector3 getDir = bl_Joystick.Instance.GetThumbDirection();

        if(getDir == Vector3.zero) return;
        StartCoroutine(Rolling(getDir));
        // if      (Input.GetKeyDown(KeyCode.UpArrow))     StartCoroutine(Rolling(Vector3.forward));
        // else if (Input.GetKeyDown(KeyCode.RightArrow))  StartCoroutine(Rolling(Vector3.right));
        // else if (Input.GetKeyDown(KeyCode.DownArrow))   StartCoroutine(Rolling(Vector3.down));
        // else if (Input.GetKeyDown(KeyCode.LeftArrow))   StartCoroutine(Rolling(Vector3.left));
    }


    private bool doubleMoveFlag = false;
    private bool flag = false;
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
        Vector3 rotateAxis = Vector3.right;

        yield return null;
        if(!rotateTarget.GetComponent<CollisionCheck>().collide)
        {
            bool isDoubleMove = rotateTarget.GetComponent<CollisionCheck>().isDoubleMove;
            
            if(!doubleMoveFlag && isDoubleMove)
            {
                rotateTarget = roller[idx+4];
                angle += 90f;
                doubleMoveFlag = true;
                
                rotateAxis = Vector3.left;
            }
            else if (doubleMoveFlag) 
            {
                flag = true;
                doubleMoveFlag = false;
                rotateTarget = axisObject;
                if      (dir == Vector3.forward){ rotateAxis = Vector3.right; }
                else if (dir == Vector3.right)  { rotateAxis = Vector3.back; }
                else if (dir == Vector3.down)   { rotateAxis = Vector3.left; }
                else if (dir == Vector3.left)   { rotateAxis = Vector3.forward; }
            }
            // 이전 회전정보 저장
            Quaternion prevRot = rotateTarget.localRotation;
            Vector3 prevPos = rotateTarget.localPosition;

            if(flag) rotateTarget.localPosition -= new Vector3(0, this.transform.localScale.x, 0);
            

            // 회전축에 player 넣기
            this.transform.parent = rotateTarget;

            while (angle > 0)
            {
                float rotateAngle = Time.deltaTime * rotateSpeed;
                if(rotateAngle >= angle) rotateAngle = angle;

                rotateTarget.Rotate(rotateAxis, rotateAngle, Space.Self);
                angle -= rotateAngle;
                yield return null;
            }

            // Player 부모 초기화
            this.transform.parent = parent;

            // 회전타겟 회전 정상화
            rotateTarget.rotation = prevRot;  
            if(flag)
            {
                rotateTarget.localPosition = prevPos;
                flag = false;
            }
            

            
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