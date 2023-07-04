using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDetect : MonoBehaviour
{

    public static bool finish = false;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish!!");
            finish = true;
        }
    }
}
