using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    public Transform arCamera;

    private void Update() 
    {
        this.transform.rotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(0, arCamera.localEulerAngles.z, 0), 0.03f);
    }
}
