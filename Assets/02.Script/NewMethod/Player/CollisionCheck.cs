using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool collide = false;
    public bool isDoubleMove = false;
    public bool isDownZone = false;

    public void Check()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Zone"))
        {
            collide = true;
        }
        if(other.gameObject.CompareTag("DownZone"))
        {
            isDownZone = true;
        }
        else if(other.gameObject.CompareTag("DoubleMove"))
        {
            isDoubleMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Zone"))
        {
            collide = false;
        }
        if(other.gameObject.CompareTag("DoubleMove"))
        {
            isDoubleMove = false;
        }
        if(other.gameObject.CompareTag("DownZone"))
        {
            isDownZone = false;
        }
    }
}
