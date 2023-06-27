using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    public Transform player;

    public float moveSpeed;

    private int moveCnt = 1;

    private float angle = 90f;
    private float hAngle = 0f;

    private bool isRotateChanged = false;
    void Update()
    {  
        if(!isRotateChanged)
        {
            switch(DrawRay.direction)
            {
                case Direction.forward  : 
                    // this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (Vector3.forward * player.localScale.x/2f); 
                    // this.transform.localRotation = Quaternion.Euler(0,0,0);
                    SetDirection(Vector3.forward, 0f);
                    break;
                case Direction.left     : 
                    // this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (Vector3.left * player.localScale.x/2f); 
                    // this.transform.localRotation = Quaternion.Euler(0,-90,0);
                    SetDirection(Vector3.left, -90f);
                    break;
                case Direction.back     : 
                    // this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (Vector3.back * player.localScale.x/2f); 
                    // this.transform.localRotation = Quaternion.Euler(0,180,0);
                    SetDirection(Vector3.back, 180f);
                    break;
                case Direction.right    : 
                    // this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (Vector3.right * player.localScale.x/2f); 
                    // this.transform.localRotation = Quaternion.Euler(0,90,0);
                    SetDirection(Vector3.right, 90f);
                    break;
            }
            isRotateChanged = true;
        }
        
        

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

    private void SetDirection(Vector3 dir, float yAngle)
    {
        this.transform.localPosition = player.localPosition + ((-Vector3.up) * player.localScale.x/2f) + (dir * player.localScale.x/2f); 
        this.transform.localRotation = Quaternion.Euler(0,yAngle,0);
    }
}