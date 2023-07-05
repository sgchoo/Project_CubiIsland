using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpCubi : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower = 2.5f;

    private void Start() 
    {
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(PopUp());
    }

    IEnumerator PopUp()
    {
        yield return new WaitForSeconds(2.5f);

        rigid.AddForce((transform.up + transform.forward) * jumpPower, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 30)
        {
            this.gameObject.layer = 0;
        }
    }
}
