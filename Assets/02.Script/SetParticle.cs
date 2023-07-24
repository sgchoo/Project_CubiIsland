using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticle : MonoBehaviour
{
    private void OnTriggerStay(Collider other) 
    {
        if(other.transform.name == "Cube")
        {
            other.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.transform.name == "Cube")
        {
            other.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
