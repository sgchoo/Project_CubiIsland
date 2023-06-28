using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RayCheck()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward + (-this.transform.up));

        RaycastHit hitInfo;

        
        if(Physics.Raycast(ray, out hitInfo, 10f))
        {
            if(hitInfo.collider.CompareTag("Zone"))
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 0.5f);
                Debug.Log("Collide!");
                return true;
            }
        }
        return false;
    }
}
