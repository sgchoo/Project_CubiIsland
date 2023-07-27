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

    public static bool isTensionActive =false;
    private Transform joystick;
    public ParticleSystem[] particles;

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
        joystick = GameObject.Find("Canvas09").transform.Find("PanelSafeArea").transform.Find("Fixed Joystick").transform;
        parent = this.transform.parent;
        childList = new List<Transform>();
        foreach(Transform child in parent)
        {   
            if(child == this.transform || child == axisObject) continue;
            childList.Add(child);
        }
        isTensionActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRolling) return;
        isTensionActive = true;
        Vector3 getDir = GetThumbDirection(joystick.GetComponent<Joystick>().Direction);

        if(getDir == Vector3.zero) return;
        StartCoroutine(Rolling(getDir));
        // if      (Input.GetKeyDown(KeyCode.UpArrow))     StartCoroutine(Rolling(Vector3.forward));
        // else if (Input.GetKeyDown(KeyCode.RightArrow))  StartCoroutine(Rolling(Vector3.right));
        // else if (Input.GetKeyDown(KeyCode.DownArrow))   StartCoroutine(Rolling(Vector3.down));
        // else if (Input.GetKeyDown(KeyCode.LeftArrow))   StartCoroutine(Rolling(Vector3.left));
    }

    public Vector3 GetThumbDirection(Vector2 dir)
    {
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        if(angle<0) angle+=360;

        if(dir == Vector2.zero) return Vector3.zero;
        if (angle <= 45f || angle >= 315f) // 오른쪽 방향
        {
            return Vector3.right;
        }
        else if (angle > 45f && angle <= 135f) // 위, 아래쪽 방향
        {
            return Vector3.forward;
        }
        else if (angle > 135f && angle <= 225f) // 왼쪽 방향
        {
            return Vector3.left;
        }
        else if (angle > 225f && angle < 360f)
        {
            return Vector3.down;
        }

        return Vector3.zero;
    }


    private bool doubleMoveFlag = false;
    private bool flag = false;
    private IEnumerator Rolling(Vector3 dir)
    {
        SFXSoundManager.Instance.PlayRollSound();

        isTensionActive= false;
        
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
            bool isDownZone = rotateTarget.GetComponent<CollisionCheck>().isDownZone;
            
            if(!doubleMoveFlag && isDoubleMove)
            {
                rotateTarget = roller[idx+4];
                angle += 90f;
                doubleMoveFlag = true;
                
                rotateAxis = Vector3.left;
            }
            else if (isDownZone&&doubleMoveFlag) 
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
                float rotateAngle = Time.deltaTime * rotateSpeed * 1.9f;
                if(rotateAngle >= angle) rotateAngle = angle;

                rotateTarget.Rotate(rotateAxis, rotateAngle, Space.Self);
                angle -= rotateAngle;
                yield return null;
            }

            // Player 부모 초기화
            this.transform.parent = parent;

            SFXSoundManager.Instance.PlayLandingSound();

            ParticlePlay();

            // 회전타겟 회전 정상화
            rotateTarget.rotation = prevRot;  
            if(flag)
            {
                rotateTarget.localPosition = prevPos;
                flag = false;
            }
            
            SetAxis(prevRot);
            isTensionActive = true;
            yield return new WaitForSeconds(0.5f);
            isTensionActive = false;
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

    private void ParticlePlay()
    {
        if(GameData.Instance.currentWorld.name == "Map01_Forest")
        {
            ParticleSystem particle = Instantiate(particles[0]);
            particle.transform.position = this.transform.position;
        }
        else if(GameData.Instance.currentWorld.name == "Map02_Snow")
        {
            ParticleSystem particle = Instantiate(particles[1]);
            particle.transform.position = this.transform.position;
        }
    }
}