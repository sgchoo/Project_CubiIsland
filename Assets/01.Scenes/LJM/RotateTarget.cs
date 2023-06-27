using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int moveCnt = 1;
    private float angle = 90f;
    private float hAngle = 0f;
    private bool isRotateChanged = false;
    private bool isDetect;
    public Transform player;
    public Transform detectRayDir;

    void Update()
    {  
        GetDirection();
        ObstacleDetect();
        CubeRoll();
    }

    private void GetDirection()
    {
        if(!isRotateChanged)
        {
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
            isRotateChanged = true;
        }
    }

    private void SetDirection(Vector3 dir, float yAngle)
    {
        this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (dir * player.localScale.x/2f); 
        this.transform.localRotation = Quaternion.Euler(0,yAngle,0);
    }

    private void CubeRoll()
    {
        if(isDetect) return;

        player.parent = this.transform;

        if (angle > 0f)
        {
            float rotateAngle = Time.deltaTime * moveSpeed;
            if (angle < rotateAngle) rotateAngle = angle;
            transform.Rotate(Vector3.right, rotateAngle, Space.Self);
            angle -= rotateAngle;
            return;
        }
        
        player.parent = this.transform.parent;

        moveCnt += 1;
        angle = 90f;
        if(moveCnt == 5)
        {
            hAngle += 90f;
        }
        
        transform.localRotation = Quaternion.Euler(hAngle, 0, 0);

        if(moveCnt != 5)
        {
            transform.localPosition += transform.forward * (transform.localScale.x) * 2;
        }
        else
        {
            moveCnt = -1;
        }

        isRotateChanged = false;
    }

    private void ObstacleDetect()
    {
        Ray ray = new Ray(detectRayDir.position, detectRayDir.forward);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.collider.CompareTag("Zone"))
            {
                isDetect = true;
                isRotateChanged = false;
                GetDirection();
            }
            else
            {
                isDetect = false;
            }
        }
    }
}