using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubiMove : MonoBehaviour
{
    public Transform cubiDirection;
    public Transform[] cubis;
    public WorldCubiRay cubiRay;


    [SerializeField] private float moveSpeed;
    public static bool isMoving;

    private void Start() 
    {
        moveSpeed = 0.0f;
    }

    private void Update()
    {
        if(isMoving) return;

        StartCoroutine(cubis[0].GetComponent<CubiMove>().Roll(cubiDirection.forward));
        StartCoroutine(cubis[1].GetComponent<CubiMove>().Roll(cubiDirection.forward));
        StartCoroutine(cubis[2].GetComponent<CubiMove>().Roll(cubiDirection.forward));
        StartCoroutine(cubis[3].GetComponent<CubiMove>().Roll(cubiDirection.forward));
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.name == "Floor")
        {
            StartCoroutine(ChangeRot());
        }
    }

    IEnumerator ChangeRot()
    {
        yield return new WaitForSeconds(1.0f);

        this.transform.eulerAngles = Vector3.zero;
        cubiDirection.eulerAngles = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        cubiRay.enabled = true;

        moveSpeed = 1.5f;
    }

    public IEnumerator Roll(Vector3 dir)
    {
        isMoving = true;

        float angle = 90;
        Vector3 anchor = this.transform.localPosition + dir * (this.transform.localScale.x) + (-cubiDirection.up) * (this.transform.localScale.x);
        Vector3 axis = Vector3.Cross(cubiDirection.up, dir);

        if (angle > 0f)
        {
            float rotateAngle = Time.deltaTime * moveSpeed;
            if (angle < rotateAngle) rotateAngle = angle;
            transform.RotateAround(anchor, axis, moveSpeed);
            angle -= rotateAngle;
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }
}
