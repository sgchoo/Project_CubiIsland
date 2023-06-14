using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 200f;

    bool isMove = false;

    bool isBorder;

    Rigidbody rigid;

    private void Start() 
    {
        rigid = GetComponent<Rigidbody>();
        isMove = true;
        Invoke("BoolValueInit", 1f);
    }

    void Update()
    {
        if(isMove)return;
   
        StartCoroutine(Rolling(Vector3.forward));
    }

    void BoolValueInit()
    {
        isMove = false;
        this.transform.parent = null;
    }

    private IEnumerator Rolling(Vector3 dir)
    {
        
        isMove = true;

        float angle = 90;

        Vector3 center = transform.position + (dir / 2) * transform.localScale.x + (Vector3.down / 2) * transform.localScale.x;

        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        while (angle > 0)
        {
            float rotationAngle = Time.deltaTime * speed;
            transform.RotateAround(center, axis, rotationAngle);
            angle -= rotationAngle;
            yield return null;
        }

        isMove = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag("Zone") && !isBorder)
        {
            StartCoroutine(PauseMove());
        }
    }

    IEnumerator PauseMove()
    {
        yield return new WaitForSeconds(0.03f);

        isBorder = true;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("World").transform);
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        this.transform.localScale = new Vector3(2f, 2f, 2f);
        speed = 0;

        yield return new WaitForSeconds(1.5f);

        this.transform.parent = null;
        this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        speed = 40f;

        yield return new WaitForSeconds(1.0f);
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        speed = 200f;
        isBorder = false;
    }
}
