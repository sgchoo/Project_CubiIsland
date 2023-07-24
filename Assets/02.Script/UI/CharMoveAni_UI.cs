using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoveAni_UI : MonoBehaviour
{
    public float RotLeft;
    public float RotRight;
    private RectTransform rectTransform;

    private bool isMovingLeft = true;
    private float rotationAmount;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        RotRight = 15f;
        RotLeft = 15f;
    }

    void Update()
    {

    }

    public void AnimationFinished()
    {
        print("애니메이션 종료, 회전 실행");
        // 애니메이션이 끝났을 때 실행
    }

    private void PlayRotate()
    {
        float rotationSpeed = isMovingLeft ? rotationAmount : -rotationAmount;
        rotationSpeed *= Time.deltaTime;

        rectTransform.Rotate(0f, 0f, rotationSpeed);

        // 회전 각도가 일정 범위를 벗어나면 방향을 전환
        if (isMovingLeft && rectTransform.eulerAngles.z <= 180f - rotationAmount)
        {
            isMovingLeft = false;
        }
        else if (!isMovingLeft && rectTransform.eulerAngles.z >= 180f + rotationAmount)
        {
            isMovingLeft = true;
        }
    }
}
