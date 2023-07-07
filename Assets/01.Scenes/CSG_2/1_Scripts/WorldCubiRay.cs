using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCubiRay : MonoBehaviour
{
    public Transform cubiScale;

    private void Update() 
    {
        DetectFall();
    }

    private void DetectFall()
    {
        RaycastHit hitInfo;

        Ray ray = new Ray(this.transform.position + (this.transform.forward * cubiScale.localScale.x * 2), Vector3.down);

        if(Physics.Raycast(ray, out hitInfo, 0.05f))
        {
            if(hitInfo.transform.name != "Floor")
            {
                this.transform.localRotation = Quaternion.Euler(0, -this.transform.localRotation.y, 0);
            }
        }
    }
}