using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 200;

    bool isMove = false;

    bool isBorder;

    Rigidbody rigid;

    private void Start() 
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isMove)return;
   
        StartCoroutine(Rolling(Vector3.forward));
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
        speed = 0;

        yield return new WaitForSeconds(1.5f);

        speed = 40;

        yield return new WaitForSeconds(1.0f);
        this.transform.parent = null;
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        speed = 200;
        isBorder = false;
    }
}
