using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    public static bool clear = false;
    // Start is called before the first frame update
    
    private void Start() 
    {
        clear = false;
    }


    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.CompareTag("None"))
        {
            return;
        }    
        else if (other.gameObject.CompareTag("Player"))
        {
            clear = true;
        }
    }

    // private void OnTriggerEnter(Collision other) 
    // {
    //     Debug.Log(other.gameObject.name);
    //     if(other.gameObject.CompareTag("None"))
    //     {
    //         return;
    //     }    
    //     else if (other.gameObject.CompareTag("Player"))
    //     {
    //         clear = true;
    //     }
    // }
}
