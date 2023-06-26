using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = player.localPosition + (-player.up * player.localScale.x)/2 + (player.forward * player.localScale.x)/2;
    }

    private float timer = 0f;

    private int moveCnt = 1;

    private float angle = 90f;
    private float hAngle = 0f;
    // Update is called once per frame
    void Update()
    {
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
        
        transform.localRotation = Quaternion.Euler(hAngle,0,0);

        if(moveCnt != 5)
        {
            transform.localPosition += transform.forward * (transform.localScale.x)*2;
        }
        else 
        {
            moveCnt = -1;
        }
        


        
        
    }
}
