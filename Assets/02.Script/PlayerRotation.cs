using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] int rollSpeed = 3;

    public Transform tr;

    bool isMove = false;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(isMove)return;

        Assemble(Vector3.forward);

        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Rolling(anchor, axis));
        }

        Debug.Log(Physics.gravity);
    }
    private IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        
        isMove = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMove = false;
    }

    // private void OnCollisionEnter(Collision other) 
    // {
    //          if(other.collider.CompareTag("Side1")) Physics.gravity = Vector3.down * 9.8f;
    //     //else if(other.collider.CompareTag("Side2")) Physics.gravity = Vector3.left * 9.8f;
    //     //else if(other.collider.CompareTag("Side3")) Physics.gravity = Vector3.back * 9.8f;
    //     else if(other.collider.CompareTag("Side4")) Physics.gravity = Vector3.back * 9.8f;
    //     //else if(other.collider.CompareTag("Side5")) Physics.gravity = Vector3.up * -9.8f;
    //     //else if(other.collider.CompareTag("Side6")) Physics.gravity = Vector3.forward * -9.8f;
    // }
}
