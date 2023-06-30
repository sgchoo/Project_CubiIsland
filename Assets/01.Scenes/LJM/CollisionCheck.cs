using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public static bool collide = false;



    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Zone"))
        {
            collide = true;
        }    
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.CompareTag("Zone"))
        {
            collide = false;
        }    
    }
}
