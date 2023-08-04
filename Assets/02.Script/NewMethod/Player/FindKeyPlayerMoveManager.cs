
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis { x, y, z, mx, my, mz };
public class FindKeyPlayerMoveManager : MonoBehaviour
{
    // 각 면의 Roller를 저장해둘 배열
    public Transform[] upArea;
    public Transform[] forwardArea;
    public Transform[] downArea;
    public Transform[] backArea;
    public Transform[] leftArea;
    public Transform[] rightArea;

    // y축의 롤러에 각도 문제가 있어서, 따로 관리하기 위해 배열을 놔둠
    // 이 문제를 에디터로만 해결하려면 다른 축의 각도를 건드리거나 새로운 축을 하나씩 더 생성해야함.
    public Transform[] yAxis;

    // 큐브 회전 속도
    public float rotateSpeed;

    // 카메라의 컴포넌트를 가져오기 위해 arCamera변수 설정
    public Transform arCamera;
    
    // 플레이어의 현재 좌표를 저장해둘 변수
    // 좌우/상하가 특정 수 이상 이동했다면 바닥으로 턴 하도록 함.
    private Vector2 coords;

    // 플레이어의 부모 객체
    private Transform parent;

    // 방향을 지정해주는 enum 변수 (forward, left, back, right, none)
    private Direction direction;

    // 플레이어의 회전 중 상태를 표현하는 변수
    private bool isRolling = false;

    // 현재 플레이어가 있는 축을 알아내기 위해 Axis 변수 생성(x, y, z, mx, my, mz)
    public Axis axis;

    private bool isChangeAxis = false;

    private List<Transform> childList;

    private Vector3 rotateAxis;

    private Transform[] roller;

    private Vector2 detectCoords;

    public ActivateDirArea activateArea;
    
    public Vector2 setCoords;
    public ParticleSystem[] particles;
    public static bool isTensionActive =false;

    void Start()
    {
        coords = setCoords;

        arCamera = Camera.main.transform;
        parent = this.transform.parent;

        //axis = Axis.y;
        rotateAxis = Vector3.right;

        activateArea.ActivateArea(axis);

        childList = new List<Transform>();
        foreach(Transform child in parent)
        {   
            if(child == this.transform || child == axisObject) continue;
            childList.Add(child);
        }
        isTensionActive = false;
    }    

    void Update()
    {
        if(FindKeyGameManager.gameOver) return;
        if(isRolling) return;
        isTensionActive = true;
        if(isChangeAxis) 
        { 
            ChangeMoveAxis();
            activateArea.ActivateArea(axis);
            coords = detectCoords;
            isChangeAxis = false;
        }
        else
        {
            switch(axis)
            {
                case Axis.x :  roller = rightArea;   rotateAxis = Vector3.left; break;
                case Axis.y :  roller = upArea;      rotateAxis = Vector3.right; break;
                case Axis.z :  roller = forwardArea; rotateAxis = Vector3.left;  break;
                case Axis.mx : roller = leftArea;    rotateAxis = Vector3.left; break;
                case Axis.my : roller = downArea;    rotateAxis = Vector3.right; break;
                case Axis.mz : roller = backArea;    rotateAxis = Vector3.left; break;
            }

            RotateYAxis(axis == Axis.x || axis == Axis.mx);

            SetDirection();
        }
    }

    private void RotateYAxis(bool isX)
    {
        if(isX)
        {
            yAxis[0].rotation = Quaternion.Euler(0,0,90);
            yAxis[1].rotation = Quaternion.Euler(0,0,90);
            yAxis[2].rotation = Quaternion.Euler(0,0,-90);
            yAxis[3].rotation = Quaternion.Euler(0,0,-90);
        }
        else 
        {
            yAxis[0].rotation = Quaternion.Euler(0,0,-90);
            yAxis[1].rotation = Quaternion.Euler(0,0,-90);
            yAxis[2].rotation = Quaternion.Euler(0,0,90);
            yAxis[3].rotation = Quaternion.Euler(0,0,90);
        }

    }

    private void ChangeMoveAxis()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
            axis = other.gameObject.GetComponent<DetectArea>().changeAxis; 
        if (other.gameObject.name == "Ground")
            detectCoords = other.gameObject.GetComponent<CoordsInfo>().GetCoords();
    }

    public Transform axisObject;
    
    private IEnumerator Rolling(Vector3 dir)
    {
        SFXSoundManager.Instance.PlayRollSound();

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
            if      (dir == Vector3.forward){ coords.y += 1; }
            else if (dir == Vector3.right)  { coords.x += 1; }
            else if (dir == Vector3.down)   { coords.y -= 1; }
            else if (dir == Vector3.left)   { coords.x -= 1; }


            // 이전 회전정보 저장
            Quaternion prevRot = rotateTarget.localRotation;

            // 회전축에 player 넣기
            this.transform.parent = rotateTarget;

            bool isTurn = CalculateCoords();
            if(isTurn) angle += 90f;

            while (angle > 0)
            {
                float rotateAngle = Time.deltaTime * rotateSpeed * 1.7f;
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

            SetAxis(prevRot);
            
            isChangeAxis = isTurn;
            
            isTensionActive = true;
            yield return new WaitForSeconds(0.3f);
            isTensionActive = false;
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
        direction = arCamera.GetComponent<PlayerDirectionManager>().RayForDirection(); 
        if(direction == Direction.none) return;

        switch(direction) 
        {
            case Direction.forward : StartCoroutine(Rolling(Vector3.forward)); break;
            case Direction.right : StartCoroutine(Rolling(Vector3.right)); break;
            case Direction.back : StartCoroutine(Rolling(Vector3.down)); break;
            case Direction.left : StartCoroutine(Rolling(Vector3.left)); break;
        }
        
    }

    private bool CalculateCoords()
    {
        bool isTurn = true;
        if      (coords.y > 4) coords.y = 0;
        else if (coords.y < 0) coords.y = 4;
        else if (coords.x > 4) coords.x = 0;
        else if (coords.x < 0) coords.x = 4;
        else                   isTurn = false;

        return isTurn;
    }

    private void ParticlePlay()
    {
        if(GameData.Instance.currentWorld.name == "Map01_Forest")
        {
            ParticleSystem particle = Instantiate(particles[0]);
            particle.transform.position = this.transform.position;
            switch(axis)
            {
                case Axis.y:
                case Axis.my:
                    particle.transform.rotation = Quaternion.Euler(-90f,0,0);
                    break;
                case Axis.z:
                case Axis.mz:
                    particle.transform.rotation = Quaternion.Euler(0,-90f,-90f);
                    break;
                case Axis.x:
                case Axis.mx:
                    particle.transform.rotation = Quaternion.Euler(0,0,-90f);
                    break;

            }

        }
        else if(GameData.Instance.currentWorld.name == "Map02_Snow")
        {
            ParticleSystem particle = Instantiate(particles[1]);
            particle.transform.localPosition = this.transform.localPosition;
            particle.transform.localRotation = this.transform.localRotation;
        }
    }
}
