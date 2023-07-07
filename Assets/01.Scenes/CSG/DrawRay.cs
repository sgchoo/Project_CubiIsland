
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {forward, left, back, right, none};
public class DrawRay : MonoBehaviour
{
    // 현재 플레이어 위치를 저장할 변수
    public Transform player;

    // 카메라의 Ray와 그에 맞닿은 cube를 이용해 플레이어의 진행 방향을 저장할 변수
    public static Direction direction = Direction.forward;

    public static Axis hitAxis;
    private void Start() 
    {
        direction = Direction.none;    
    }

    private void Update() 
    {
        //RayForDirection();
    }

    public Direction RayForDirection()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider == null) return Direction.none;
            Vector3 offset = hit.point - hit.collider.transform.position;
            
            if (hit.collider.transform.GetComponent<DetectArea>() == null) return Direction.none;
            hitAxis = hit.collider.transform.GetComponent<DetectArea>().changeAxis;
            
            if (hitAxis == Axis.x)
            {
                // 제1분면 
                if      (offset.y < 0.0f && offset.z > 0.0f) { direction = Direction.forward;   }
                // 제2분면 
                else if (offset.y < 0.0f && offset.z < 0.0f) { direction = Direction.left;      }
                // 제3분면 
                else if (offset.y > 0.0f && offset.z < 0.0f) { direction = Direction.back;      }
                // 제4분면 
                else if (offset.y < 0.0f && offset.z < 0.0f) { direction = Direction.right;     }
            }
            else if (hitAxis == Axis.y)
            {
                // 제1분면 
                if      (offset.x > 0.0f && offset.z > 0.0f) { direction = Direction.forward; }
                // 제2분면 
                else if(offset.x < 0.0f && offset.z > 0.0f)  { direction = Direction.left; }
                // 제3분면 -,-
                else if(offset.x < 0.0f && offset.z < 0.0f)  { direction = Direction.back; }
                // 제4분면 +,-
                else if(offset.x > 0.0f && offset.z < 0.0f)  { direction = Direction.right; }
            }
            else if (hitAxis == Axis.z)
            {
                // 제1분면 
                if      (offset.x > 0.0f && offset.y < 0.0f) { direction = Direction.forward; }
                // 제2분면 
                else if (offset.x < 0.0f && offset.y < 0.0f) { direction = Direction.left; }
                // 제3분면 
                else if (offset.x < 0.0f && offset.y > 0.0f) { direction = Direction.back; }
                // 제4분면 
                else if (offset.x > 0.0f && offset.y > 0.0f) { direction = Direction.right; }
            }
            else if (hitAxis == Axis.mx)
            {
                // 제1분면 
                if(offset.y > 0.0f && offset.z > 0.0f) { direction = Direction.forward; }
                // 제2분면 
                else if(offset.y < 0.0f && offset.z > 0.0f) { direction = Direction.left; }
                // 제3분면 
                else if(offset.y < 0.0f && offset.z < 0.0f) { direction = Direction.back; }
                // 제4분면 
                else if(offset.y > 0.0f && offset.z < 0.0f) { direction = Direction.right; }
            }
            else if (hitAxis == Axis.my)
            {
                // 제1분면 +,+
                if(offset.x > 0.0f && offset.z < 0.0f) { direction = Direction.forward; }
                // 제2분면 -,+
                else if(offset.x < 0.0f && offset.z < 0.0f) { direction = Direction.left; }
                // 제3분면 -,-
                else if(offset.x < 0.0f && offset.z > 0.0f) { direction = Direction.back; }
                // 제4분면 +,-
                else if(offset.x > 0.0f && offset.z > 0.0f) { direction = Direction.right; }
            }
            else if (hitAxis == Axis.mz)
            {
                // 제1분면 +,+
                if(offset.x > 0.0f && offset.y > 0.0f) { direction = Direction.forward; }
                // 제2분면 -,+
                else if(offset.x < 0.0f && offset.y > 0.0f) { direction = Direction.left; }
                // 제3분면 -,-
                else if(offset.x < 0.0f && offset.y < 0.0f) { direction = Direction.back; }
                // 제4분면 +,-
                else if(offset.x > 0.0f && offset.y < 0.0f) { direction = Direction.right; }
            }

            Debug.Log( hitAxis + " " + offset + " " + direction );

            // // 제1분면 +,+
            // if(offset.x > 0.0f && offset.z > 0.0f) 
            // {   
            //     direction = Direction.forward;
            // }
            // // 제2분면 -,+
            // else if(offset.x < 0.0f && offset.z > 0.0f) 
            // {
            //     direction = Direction.left;
            // }
            // // 제3분면 -,-
            // else if(offset.x < 0.0f && offset.z < 0.0f) 
            // {
            //     direction = Direction.back;
            // }
            // // 제4분면 +,-
            // else if(offset.x > 0.0f && offset.z < 0.0f) 
            // {
            //     direction = Direction.right;
            // }
            // else 
            // {
            //     direction = Direction.forward;
            // }
        }
        return direction;
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
