using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.right);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, 15.0f))
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
