using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    public static bool clear = false;
    // Start is called before the first frame update
    private bool noneFlag = false;
    
    private void Start() 
    {
        clear = false;
    }


    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.CompareTag("None"))
        {
            noneFlag =true;
            return;
        }    
        if (!noneFlag && other.gameObject.CompareTag("Player"))
        {
            Handheld.Vibrate();
            clear = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("None"))
        {
            noneFlag =false;
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
