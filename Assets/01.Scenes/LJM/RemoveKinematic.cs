using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveKinematic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetSomething());
    }

    private IEnumerator GetSomething()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<Rigidbody>().isKinematic = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
