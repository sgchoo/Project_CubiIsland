using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool collide = false;

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
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Zone"))
        {
            collide = false;
        }
    }
}
