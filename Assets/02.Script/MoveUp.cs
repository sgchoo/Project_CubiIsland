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
        this.transform.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        this.transform.GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSeconds(2.0f);

        transform.DOMoveZ(-0.5f, 1.0f).SetEase(Ease.Unset).SetLoops(1).SetRelative();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 30)
        {
            this.gameObject.layer = 0;

            if(this.transform.GetChild(0) != null)
            {
                this.transform.GetChild(0).gameObject.layer = 0;
            }
        }
    }
}
