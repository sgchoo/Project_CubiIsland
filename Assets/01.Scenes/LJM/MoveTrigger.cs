using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{

    public static int triggerCount = 0;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            triggerCount += 1;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            triggerCount -= 1;
        }    
    }

    // private void Update() {
    //     Debug.Log("MoveTrigger : " + triggerCount);
    // }
}
