using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindKeyPlayerMove : MonoBehaviour
{
    public Transform arCamera;
    
    public Transform multiTarget;


    private Quaternion currentRot;

    void Start()
    {
        currentRot = transform.rotation;
    }

    private float timer = 0f;

    public Transform rotTarget;
    public Transform cube;
    private float angle = 90f;


    void Update()
    {
        if (isMove) return;
        if (DetectArea.changes)
        {
            currentRot = transform.rotation;
        }
    }


    private float elapsedTime;
    private float duration;
    private bool isMove = false;
    // private IEnumerator Rolling()
    // {
    //     isMove = true;
        
        

    //     isMove = false;
    // }

    // private Quaternion GetCameraAxis()
    // {
    //     Debug.Log("GetAxis");
    //     string debugString = "";
    //     Quaternion returnValue = default(Quaternion);

    //     float rotAngle =  currentRot.eulerAngles.x;
    //     switch(DetectArea.axis)
    //     {
    //         case Axis.x  : rotAngle =  currentRot.eulerAngles.x; debugString += "x축";  break;
    //         case Axis.y  : rotAngle =  currentRot.eulerAngles.y; debugString += "y축";  break;
    //         case Axis.z  : rotAngle =  currentRot.eulerAngles.z; debugString += "z축";  break;
    //         case Axis.mx : rotAngle = -currentRot.eulerAngles.x; debugString += "-x축"; break;
    //         case Axis.my : rotAngle = -currentRot.eulerAngles.y; debugString += "-y축"; break;
    //         case Axis.mz : rotAngle = -currentRot.eulerAngles.z; debugString += "-z축"; break;
    //     }
        
    //     switch((int)rotAngle/90f)
    //     {
    //         case 0 : 
    //             //Debug.Log(debugString + "정면" + rotAngle + ", " + (int)rotAngle/90f); 
    //             returnValue = Quaternion.Euler(0,0,0);
    //             this.transform.localRotation = returnValue;
    //             break;
    //         case 1 : 
    //             //Debug.Log(debugString + "오른면"); 
    //             returnValue = Quaternion.Euler(0,90,0);
    //             this.transform.localRotation = returnValue;
    //             break;
    //         case 2 : 
    //             //Debug.Log(debugString + "뒷면"); 
    //             returnValue = Quaternion.Euler(0,180,0);
    //             this.transform.localRotation = returnValue;
    //             break;
    //         case 3 : 
    //             //Debug.Log(debugString + "왼면"); 
    //             returnValue = Quaternion.Euler(0,270,0);
    //             this.transform.localRotation = returnValue;
    //             break;

    //     }
        
        

    //     return returnValue;

    // }

}
