using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;

    private bool isRoll;

    private void Update() 
    {
        if(isRoll) return;

        RollCube();
    }

    private void RollCube()
    {
        var anchor = this.transform.position + (Vector3.down + Vector3.forward);
        var axis = Vector3.Cross(Vector3.up, Vector3.forward);
        StartCoroutine(Rolling(anchor, axis));
    }

    IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        isRoll = true;

        for(int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isRoll = false;
    }
}
