using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCubiRay : MonoBehaviour
{
    // public Transform[] cubisTr;

    // ranValue ran = new ranValue();

    // private void Start() 
    // {
    //     Invoke("RandomValue", 5.0f);
    // }

    // private void Update() 
    // {
    //     DetectFall();
    // }

    // private void RandomValue()
    // {
    //     ran.random = UnityEngine.Random.Range(0, 4);

    //     Invoke("RandomValue", 5.0f);
    // }

    // private void DetectFall()
    // {
    //     RaycastHit hitInfo;

    //     Ray ray = new Ray(this.transform.position + (this.transform.forward * cubisTr[0].localScale.x * 2), Vector3.down);

    //     if(Physics.Raycast(ray, out hitInfo, 0.05f))
    //     {
    //         if(hitInfo.transform.name != "Floor")
    //         {
    //             this.transform.localRotation = Quaternion.Euler(0, -ran.random, 0);
    //         }
    //     }
    // }
}