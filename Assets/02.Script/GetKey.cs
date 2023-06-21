using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary>
// Trigger되면
// GameManager의 Key 카운트가 증가되고
// 특정 개수가 되면
// 전개도가 펼쳐진다.

//</Summary>

public class GetKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag("Player")) 
        {
            GameManager.keyCount++;
            Destroy(this.gameObject);
        }
    }
}
