using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionManager : MonoBehaviour
{

    public static Direction direction = Direction.none;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayForDirection();
    }

    public Direction RayForDirection()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;

        direction = Direction.none;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider == null) return Direction.none;
            
            switch(hit.collider.transform.name)
            {
                case "forward"  : direction = Direction.forward; break;
                case "right"    : direction = Direction.right;   break;
                case "back"     : direction = Direction.back;    break;
                case "left"     : direction = Direction.left;    break;
            }
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
