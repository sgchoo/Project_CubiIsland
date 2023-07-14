using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoveAni_UI : MonoBehaviour
{
    public float RotLeft;
    public float RotRight;
    private RectTransform rectTransform;

    private bool isMovingLeft = true;
    public float rotationAmount;
    private float rotationSpeed;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        rotationSpeed = isMovingLeft ? rotationAmount : -rotationAmount;
        RotRight = 15f;
        RotLeft = 15f;
    }

    private bool isGo = false;

    void Update()
    {
        if(isGo)
        {
            PlayRotate();
            return;
        }
        //PlayRotate();
    }


    public void AnimationFinished()
    {
        print("애니메이션 종료, 회전 실행");
        // 애니메이션이 끝났을 때 실행
        animator.enabled = false;
        isGo = true;
    }

    private float totalRotateValue = 0f;
    private void PlayRotate()
    {
        print("회전 실행");
        
        rotationSpeed *= 0.97f;
        totalRotateValue += rotationSpeed;
        if(Mathf.Abs(totalRotateValue) >= 1000f) 
        {
            totalRotateValue = 0;
            isMovingLeft = !isMovingLeft;
            rotationSpeed = isMovingLeft ? rotationAmount : -rotationAmount;
            return;
        }
        Debug.Log("TOTAL::"+totalRotateValue);
        
        rectTransform.Rotate(new Vector3(0f, 0f, rotationSpeed)*Time.deltaTime, Space.Self);

        //회전 각도가 일정 범위를 벗어나면 방향을 전환
        // if (isMovingLeft && rectTransform.eulerAngles.z <= 180f - rotationAmount)
        // {
        //     Debug.Log("Left");
        //     isMovingLeft = false;
        // }
        // else if (!isMovingLeft && rectTransform.eulerAngles.z >= 180f + rotationAmount)
        // {
        //     Debug.Log("Right");
        //     isMovingLeft = true;
        // }
        
    }
}
