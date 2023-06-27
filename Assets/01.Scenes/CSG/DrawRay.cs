
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {forward, left, back, right};
public class DrawRay : MonoBehaviour
{
    public static bool isBlockZone;
    public Transform player;
    public static Direction direction = Direction.forward;
    
    private void Update() 
    {
        RayForDirection();
    }

    private void RayForDirection()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 offset = hit.point - player.position;

            // 제1분면 +,+
            if(offset.x > 0 && offset.z > 0) 
            {   
                direction = Direction.forward;
            }
            // 제2분면 -,+
            else if(offset.x < 0 && offset.z > 0) 
            {
                direction = Direction.left;
            }
            // 제3분면 -,-
            else if(offset.x < 0 && offset.z < 0) 
            {
                direction = Direction.back;
            }
            // 제4분면 +,-
            else if(offset.x > 0 && offset.z < 0) 
            {
                direction = Direction.right;
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Ray gizmoRay = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hitInfo;

        if(Physics.Raycast(gizmoRay, out hitInfo))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hitInfo.point, 0.003f);
        }
    }
}
