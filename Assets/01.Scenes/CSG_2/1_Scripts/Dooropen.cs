using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dooropen : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(90, 0, 0), 1.0f).SetLoops(1).SetEase(Ease.Unset);
    }
}
