using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAxis : MonoBehaviour
{
    public static Axis axis;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.name == "Cube")
        {
            axis = other.gameObject.GetComponent<DetectArea>().changeAxis;
        }
    }
}
