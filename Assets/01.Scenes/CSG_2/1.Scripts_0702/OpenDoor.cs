using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenDoor : MonoBehaviour
{
    private void Start() 
    {
        transform.DOLocalRotate(new Vector3(90, 0, 0), 1.0f).SetEase(Ease.Unset).SetLoops(1);
    }
}
