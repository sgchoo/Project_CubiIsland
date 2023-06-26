using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;

public class TM : MonoBehaviour
{
    [SerializeField] private RotateTarget rotTarget;
    public Transform arCamera;

    private void Start() 
    {
        rotTarget = GameObject.Find("RotationTargetForward").GetComponent<RotateTarget>();
    }

    private void Update() 
    {
        if(rotTarget.rollCnt == 2)
        {
            this.transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        else if(rotTarget.rollCnt == 3)
        {
            this.transform.localRotation = Quaternion.Euler(180, 0, 0);
        }
        else if(rotTarget.rollCnt == 4)
        {
            this.transform.localRotation = Quaternion.Euler(270, 0, 0);
        }
        else if(rotTarget.rollCnt == 5)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            rotTarget.rollCnt = 1;
        }

        if(arCamera.localEulerAngles.z < 90 && arCamera.localEulerAngles.z > 0)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(0, 90, 0), 0.03f);
        }
        else if(arCamera.localEulerAngles.z < 180 && arCamera.localEulerAngles.z > 90)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(0, 180, 0), 0.03f);
        }
        else if(arCamera.localEulerAngles.z < 270 && arCamera.localEulerAngles.z > 180)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(0, 270, 0), 0.03f);
        }
        else if(arCamera.localEulerAngles.z < 360 && arCamera.localEulerAngles.z > 270)
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.Euler(0, 0, 0), 0.03f);
        }

    }
}
