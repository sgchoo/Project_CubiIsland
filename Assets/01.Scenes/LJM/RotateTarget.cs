using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    // 큐브의 회전 속도
    [SerializeField] private float moveSpeed;
    // [SerializeField] private int moveCnt = 1;

    // 큐브의 x, y좌표 저장 변수
    public int x = 2;
    public int y = 1;

    // 큐브의 회전 각도
    private float angle = 90f;

    // 큐브가 일정 이상 이동하여 회전할 때 그 각도를 저장해둘 변수
    private float hAngle = 0f;
    private float vAngle = 0f;

    // 큐브가 1회전을 끝남을 체크하기 위한 변수
    private bool isRotateChanged = false;

    // ???
    private bool isDetect;

    // 큐브가 일정 이상 이동하여 회전할 때 이를 체크하기 위한 변수
    private bool isTurn = false;

    // 플레이어 캐릭터
    public Transform player;

    // ???
    public Transform detectRayDir;

    // 플레이어의 회전에 도움을 줄 Axis
    public Transform playerAxis;

    // AR 카메라가 플레이어와 같은면에 있는지 확인하기 위한 변수
    public Transform arCamera;
    private Direction direction;

    void Update()
    {  
        //GetDirection();
        // 만약 큐브가 1회전 중이거나, 모서리 회전 중이 아니면 
        if(!isRotateChanged && !isTurn)
        {
            // 카메라가 바라보는 위치와 면의 정중앙 좌표를 이용해 상하좌우 단위벡터 가져오기
            direction = arCamera.GetComponent<DrawRay>().RayForDirection(); 
            
            Debug.Log("Direction : " + direction); 
            // 만약 카메라가 바라보는 면과 플레이어가 서있는 면이 다르면 함수를 종료해라
            if(DrawRay.hitAxis != CollideAxis.axis) return;

            // 가져온 단위벡터로 회전 축을 이동, 회전시킨다.
            switch(DrawRay.direction)
            {
                case Direction.forward  :
                    SetDirection(Vector3.forward, 0f);
                break;

                case Direction.left     :
                    SetDirection(Vector3.left, -90f);
                break;

                case Direction.back     :
                    SetDirection(Vector3.back, 180f);
                break;

                case Direction.right    :
                    SetDirection(Vector3.right, 90f);
                break;
            }

            // 회전이 시작되었음을 알리는 isRotateChanged를 true로 만든다.
            // isRotateChanged가 true인 동안에는, 단위 벡터를 연산하지 않는다.
            isRotateChanged = true;
        }
        //ObstacleDetect();
        Ray ray = new Ray(detectRayDir.position, detectRayDir.forward);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.collider.CompareTag("Zone"))
            {
                if (Vector3.Distance(this.transform.position, hitInfo.collider.transform.position) < 0.02f)
                {
                    isDetect = true;
                    isRotateChanged = false;
                    return;
                }
            }
            else
            {
                isDetect = false;
            }
        }

        //CubeRoll();
        // 플레이어를 현재 오브젝트인 rotateTarget에 넣는다.
        // rotateTarget을 돌리면 플레이어도 같이 돌아갈 것이다.
        player.parent = this.transform;


        // 회전 각도가 0보다 크다면 아래와 같은 코드들을 계속 반복한다.
        if (angle > 0f)
        {
            float rotateAngle = Time.deltaTime * moveSpeed;
            if (angle < rotateAngle) rotateAngle = angle;
            transform.Rotate(Vector3.right, rotateAngle, Space.Self);
            angle -= rotateAngle;
            return;
        }
        // angle을 더이상 뺄 수 없으면 회전을 종료하고 플레이어를 다시 상위 객체의 자식으로 추가한다.
        player.parent = this.transform.parent;

        // 가져온 단위 벡터에 따라, x, y변수에 이동한 거리를 1 누적한다.
        switch(direction)
        {
            case Direction.forward  : 
                y+=1;
                break;
            case Direction.left     : 
                x-=1;
                break;
            case Direction.back     : 
                y-=1;
                break;
            case Direction.right    : 
                x+=1;
                break;
        }

        if(isTurn)
        {
            playerAxis.GetComponent<BoxCollider>().enabled = false;
            playerAxis.GetComponent<BoxCollider>().enabled = true;
        }
        // isTurn 변수를 false로 초기화한다. 
        // isTurn 변수는 true가 되면 플레이어가 모서리에서 한번 더 회전할 수 있도록 한다.
        isTurn = false;

        // 만약 오른쪽으로 4칸 이상 이동했다면
        if(x == 5)
        {
            isTurn = true;
            vAngle += 90f;
            x = -1;
        }
        // 만약 왼쪽으로 4칸 이상 이동했다면
        else if(x == -1)
        {
            isTurn = true;
            vAngle -= 90f;
            x = 5;
        }
        // 만약 앞쪽으로 4칸 이상 이동했다면
        else if(y == 5)
        {
            isTurn = true;
            hAngle += 90f;
            y = -1;
        }
        // 만약 뒤쪽으로 4칸 이상 이동했다면
        else if(y == -1)
        {
            isTurn = true;
            hAngle -= 90f;
            y = 5;
        }

        // 회전 각도를 90f로 초기화한다.
        angle = 90f;

        if(!isTurn)
        {
            transform.localRotation = Quaternion.Euler(hAngle, vAngle, 0);
            playerAxis.localRotation = Quaternion.Euler(hAngle, vAngle, 0);
        }       


        isRotateChanged = false;
    }


    private void SetDirection(Vector3 dir, float y)
    {
        // this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (dir * player.localScale.x/2f); 
        // this.transform.localRotation = Quaternion.Euler(0,yAngle,0);
        Vector3 down = default(Vector3);
        if (DrawRay.hitAxis == Axis.x)
        {
            if(dir == Vector3.forward)
            {

            }
            else if (dir == Vector3.left)
            {

            }
            else if (dir == Vector3.back)
            {

            }
            else if (dir == Vector3.right)
            {
                
            }
        }
        else if (DrawRay.hitAxis == Axis.y)
        {
            down = Vector3.down;
            if(dir == Vector3.forward)
            {
                dir = Vector3.forward;
            }
            else if (dir == Vector3.left)
            {
                dir = Vector3.left;
            }
            else if (dir == Vector3.back)
            {
                dir = Vector3.back;
            }
            else if (dir == Vector3.right)
            {
                dir = Vector3.right;
            }
        }
        else if (DrawRay.hitAxis == Axis.z)
        {
            down = Vector3.back;
            if(dir == Vector3.forward)
            {
                dir = Vector3.down;
            }
            else if (dir == Vector3.left)
            {
                dir = Vector3.left;
            }
            else if (dir == Vector3.back)
            {
                dir = Vector3.up;
            }
            else if (dir == Vector3.right)
            {
                dir = Vector3.right;
            }
        }
        else if (DrawRay.hitAxis == Axis.mx)
        {
            if(dir == Vector3.forward)
            {

            }
            else if (dir == Vector3.left)
            {

            }
            else if (dir == Vector3.back)
            {

            }
            else if (dir == Vector3.right)
            {
                
            }
        }
        else if (DrawRay.hitAxis == Axis.my)
        {
            if(dir == Vector3.forward)
            {

            }
            else if (dir == Vector3.left)
            {

            }
            else if (dir == Vector3.back)
            {

            }
            else if (dir == Vector3.right)
            {
                
            }
        }
        else if (DrawRay.hitAxis == Axis.mz)
        {
            if(dir == Vector3.forward)
            {

            }
            else if (dir == Vector3.left)
            {

            }
            else if (dir == Vector3.back)
            {

            }
            else if (dir == Vector3.right)
            {
                
            }
        }

        this.transform.localPosition = player.localPosition + (down * (player.localScale.x/2f)) + (dir * (player.localScale.x/2f)); 
        this.transform.localRotation = Quaternion.Euler(hAngle, y + vAngle,0);
        // this.transform.localPosition = player.localPosition + (downAxis * (player.localScale.x/2f)) + (forwardAxis * (player.localScale.x/2f)); 
        // this.transform.localRotation = Quaternion.Euler(hAngle, y + vAngle,0);

    }

    
}