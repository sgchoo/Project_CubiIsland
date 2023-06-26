using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour
{
    public Transform player;

    private void Update() 
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 offset = hit.point - player.position;

            var dir = Mathf.Atan2(player.position.y - offset.y, player.position.x - offset.x) * Mathf.Rad2Deg;

            Debug.Log(dir);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Ray gizmoRay = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hitInfo;

        if(Physics.Raycast(gizmoRay, out hitInfo))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hitInfo.point, 0.005f);
        }
    }
}
