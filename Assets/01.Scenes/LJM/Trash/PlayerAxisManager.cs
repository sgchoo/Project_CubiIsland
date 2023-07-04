using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisManager : MonoBehaviour
{
    public Transform playerTransform;
     void Update()
    {
        this.transform.position = playerTransform.position;
    }
}
