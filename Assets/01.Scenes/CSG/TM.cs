using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;

public class TM : MonoBehaviour
{
    private void Update() 
    {
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
