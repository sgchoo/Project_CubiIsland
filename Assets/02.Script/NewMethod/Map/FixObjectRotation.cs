using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FixObjectRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    private void Start()
    {
        // A 오브젝트의 초기 회전 값을 저장
        initialRotation = transform.rotation;
        this.GetComponent<PositionConstraint>().constraintActive = true;
    }

    private void LateUpdate()
    {
        // A 오브젝트의 회전을 초기 값으로 고정
        transform.rotation = initialRotation;
        
    }
}
