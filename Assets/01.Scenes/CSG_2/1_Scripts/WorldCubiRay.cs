using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranValue
{
    public int random;
}

public class WorldCubiRay : MonoBehaviour
{
    public Transform cubiTr;

    ranValue ran = new ranValue();

    private void Start() 
    {
        Invoke("RandomValue", 5.0f);
    }

    private void Update() 
    {
        DetectFall();
    }

    private void RandomValue()
    {
        ran.random = UnityEngine.Random.Range(-180, 180);
        cubiTr.localRotation = Quaternion.Euler(cubiTr.localRotation.x, ran.random, 0);
        this.transform.localRotation = Quaternion.Euler(0, ran.random, 0);
        Invoke("RandomValue", 5.0f);
    }

    private void DetectFall()
    {
        RaycastHit hitInfo;

        Ray ray = new Ray(this.transform.position + (this.transform.forward * cubiTr.localScale.x * 2), Vector3.down);

        if(Physics.Raycast(ray, out hitInfo, 0.05f))
        {
            if(hitInfo.transform.name == "Portal" || hitInfo.transform.name == "FallingArea")
            {
                cubiTr.localRotation = Quaternion.Euler(cubiTr.localRotation.x, -ran.random, 0);
                this.transform.localRotation = Quaternion.Euler(0, -ran.random, 0);
            }
        }
    }
}