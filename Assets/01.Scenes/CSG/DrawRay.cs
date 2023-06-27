using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {forward, left, back, right};
public class DrawRay : MonoBehaviour
{
    public Transform player;
    public static Direction direction = Direction.forward;
    
    
    private void Update() 
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 offset = hit.point - player.position;

            //var dir = Mathf.Atan2(player.position.y - offset.y, player.position.x - offset.x) * Mathf.Rad2Deg;
            
            //var dir = Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg;

            //Debug.Log("offset : " + offset + "\n dir : " + dir);

            // 제1분면 +,+
            if(offset.x > 0 && offset.y > 0) 
            {   
                direction = Direction.forward;
            }
            // 제2분면 -,+
            else if(offset.x < 0 && offset.y > 0) 
            {
                direction = Direction.left;
            }
            // 제3분면 -,-
            else if(offset.x < 0 && offset.y < 0) 
            {
                direction = Direction.back;
            }
            // 제4분면 +,-
            else if(offset.x > 0 && offset.y < 0) 
            {
                direction = Direction.right;
            }
            else 
            {

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
