using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubiDirection
{
    public int ranVal;
}


public class FindLoadPlayerMoveManager : MonoBehaviour
{
    public Transform[] roller;
    public float rotateSpeed;
    public Transform parent;
    private bool isRolling = false;
    private float jumpPower;
    Rigidbody rigid;

    private List<Transform> childList;
    private List<Vector3> originPos;
    private List<Quaternion> originRot;

    public Transform axisObject;

    cubiDirection random = new cubiDirection();

    Vector3 rayDir;

    void Awake()
    {
        childList = new List<Transform>();
        originPos = new List<Vector3>();
        originRot = new List<Quaternion>();
        foreach(Transform child in parent)
        {   
            if(child == this.transform || child == axisObject) continue;
            childList.Add(child);
            originPos.Add(child.transform.localPosition);
            originRot.Add(child.transform.localRotation);
        }
    }

    void Start()
    {
        
        SetDirection();
    }

    private void OnEnable() 
    {
        this.transform.SetParent(parent);
        this.transform.localPosition = Vector3.zero;
        this.transform.rotation = Quaternion.identity;

        axisObject.localPosition = this.transform.localPosition;

        for(int i = 0; i < childList.Count; i++)
        {
            childList[i].transform.localPosition = originPos[i];
            childList[i].transform.localRotation = originRot[i];
        }

        isRolling = false;
    }

    private void OnDisable() 
    {
        StopAllCoroutines();
    }

    void Update()
    {
        FallingZoneRay();
        
        if(isActiveAndEnabled)
        {
            if(isRolling) return;

            if      (random.ranVal == 0)     StartCoroutine(Rolling(Vector3.forward));
            else if (random.ranVal == 1)     StartCoroutine(Rolling(Vector3.right));
            else if (random.ranVal == 2)     StartCoroutine(Rolling(Vector3.down));
            else if (random.ranVal == 3)     StartCoroutine(Rolling(Vector3.left));
        }
    }

    private bool doubleMoveFlag = false;
    private bool flag = false;
    private IEnumerator Rolling(Vector3 dir)
    {
        isRolling = true;

        float angle = 90f;

        int idx = -1;
        if      (dir == Vector3.forward)    { idx = 0; }
        else if (dir == Vector3.right)      { idx = 1; }
        else if (dir == Vector3.down)       { idx = 2; }
        else if (dir == Vector3.left)       { idx = 3; }

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

    private void SetDirection()
    {
        random.ranVal = UnityEngine.Random.Range(0, 4);
        Invoke("SetDirection", 3f);
    }

    private void FallingZoneRay()
    {
        switch(random.ranVal)
        {
            case 0:
                rayDir = Vector3.forward;
                break;

            case 1:
                rayDir = Vector3.right;
                break;

            case 2:
                rayDir = Vector3.back;
                break;

            case 3:
                rayDir = Vector3.left;
                break;
        }

        Ray ray = new Ray(this.transform.position, rayDir);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 0.02f))
        {
            if(hitInfo.collider.CompareTag("Zone"))
            {
                random.ranVal = UnityEngine.Random.Range(0, 4);
            }
        }
    }
}
