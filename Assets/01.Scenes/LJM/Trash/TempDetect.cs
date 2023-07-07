using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoubleMoveState{ Moving, On, Out };

public class TempDetect : MonoBehaviour
{
    public static DoubleMoveState doubleMove = DoubleMoveState.Out;

 //   public static bool doubleMove = false;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("DoubleMove") && doubleMove == DoubleMoveState.Out)
        {
            Debug.Log("Detect!!");
   //         doubleMove = true;
            doubleMove = DoubleMoveState.Moving;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(doubleMove == DoubleMoveState.On)
        {
            doubleMove = DoubleMoveState.Out;
        }    
    }
}
