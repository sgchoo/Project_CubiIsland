using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectArea : MonoBehaviour
{   
    public static Axis axis;
    public static bool changes = false;
    public Axis changeAxis = Axis.y;
    // Start is called before the first frame update
    void Start()
    {
        axis = Axis.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            axis = changeAxis;
            changes = true;
        }
        
    }

    public Axis GetChangeAxis()
    {
        return changeAxis;
    }
}
