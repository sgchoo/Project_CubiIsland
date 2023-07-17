using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    float curTime;
    public float maxTime = 2.5f;

    private void Update() 
    {
        curTime += Time.deltaTime;

        if(curTime > maxTime)
        {
            Destroy(this.gameObject);
        }
    }
}
