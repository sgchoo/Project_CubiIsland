using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float timer = 0f;

    float angle = 90f;
    // Update is called once per frame
    void Update()
    {
        // if(timer < 3f)
        // {
        //     timer += Time.deltaTime;
        //     return;
        // }
        // timer = 0f;

        if (angle > 0f)
        {
            float rotateAngle = Time.deltaTime * 50f;
            if (angle < rotateAngle) rotateAngle = angle;
            transform.Rotate(Vector3.right, rotateAngle, Space.Self);
            angle -= rotateAngle;
            return;
        }

        angle = 90f;
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.localPosition += Vector3.forward * (transform.localScale.x)*2;


        
        // transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90f,0,0), 10f);

        // if(transform.localRotation.x == 90f)
        // {
        //     transform.localRotation = Quaternion.Euler(0,0,0);
        //     transform.localPosition += transform.forward;
        // }
        
    }
}
