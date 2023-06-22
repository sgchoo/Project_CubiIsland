using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;
    }
}
