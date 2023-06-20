using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = target.transform.rotation;
    }
}
