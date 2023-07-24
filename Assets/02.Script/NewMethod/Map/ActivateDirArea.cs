using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDirArea : MonoBehaviour
{
    public Transform[] DirArea;

    public void ActivateArea(Axis axis)
    {
        foreach(Transform area in DirArea)
        {
            area.gameObject.SetActive(false);
        }

        switch(axis)
        {
            case Axis.x:  DirArea[0].gameObject.SetActive(true); break;   
            case Axis.y:  DirArea[1].gameObject.SetActive(true); break;   
            case Axis.z:  DirArea[2].gameObject.SetActive(true); break;   
            case Axis.mx: DirArea[3].gameObject.SetActive(true); break;   
            case Axis.my: DirArea[4].gameObject.SetActive(true); break;   
            case Axis.mz: DirArea[5].gameObject.SetActive(true); break;   
        }
    }
}
