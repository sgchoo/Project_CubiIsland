using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveUp : MonoBehaviour
{
    private void Start() 
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(2.0f);

        transform.DOMoveY(0.35f, 1.0f).SetEase(Ease.Unset).SetLoops(1).SetRelative();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 30)
        {
            this.gameObject.layer = 0;
            // 자식 오브젝트도 레이어 변경시키기
            if(this.transform.GetChild(0) != null)
            {
                this.transform.GetChild(0).gameObject.layer = 0;
            }
        }
    }
}
