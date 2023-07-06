using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranValue
{
    public int random;
}

public class CubiMove : MonoBehaviour
{
    public Transform[] cubiDirections;
    public Transform[] cubis;
    public WorldCubiRay cubiRay;

    ranValue ran = new ranValue();
    Vector3 direction;


    [SerializeField] private float moveSpeed;
    public static bool isMoving;

    private void Start() 
    {
        moveSpeed = 0.0f;
        Invoke("RandomValue", 5.0f);
    }

    private void Update()
    {
        if(isMoving) return;

        switch(ran.random)
        {
            case 0:
                direction = Vector3.forward;
                break;
            case 1:
                direction = Vector3.right;
                break;
            case 2:
                direction = Vector3.left;
                break;
            case 3:
                direction = Vector3.back;
                break;
        }

        StartCoroutine(cubis[0].GetComponent<CubiMove>().Roll(direction, cubiDirections[0].localPosition));
        StartCoroutine(cubis[1].GetComponent<CubiMove>().Roll(direction, cubiDirections[1].localPosition));
        StartCoroutine(cubis[2].GetComponent<CubiMove>().Roll(direction, cubiDirections[2].localPosition));
        StartCoroutine(cubis[3].GetComponent<CubiMove>().Roll(direction, cubiDirections[3].localPosition));
    }

    private void RandomValue()
    {
        ran.random = UnityEngine.Random.Range(0, 4);

        Invoke("RandomValue", 5.0f);
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
        cubiDirections[0].eulerAngles = Vector3.zero;
        cubiDirections[1].eulerAngles = Vector3.zero;
        cubiDirections[2].eulerAngles = Vector3.zero;
        cubiDirections[3].eulerAngles = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        cubiRay.enabled = true;

        moveSpeed = 3f;
    }

    public IEnumerator Roll(Vector3 dir, Vector3 position)
    {
        isMoving = true;

        float angle = 90;
        Vector3 anchor = position + dir * (this.transform.localScale.x) + Vector3.down * (this.transform.localScale.x);
        Vector3 axis = Vector3.Cross(Vector3.up, dir);

        if (angle > 0f)
        {
            float rotateAngle = Time.deltaTime * moveSpeed;
            if (angle < rotateAngle) rotateAngle = angle;
            transform.RotateAround(anchor, axis, moveSpeed);
            angle -= rotateAngle;
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;

        yield return new WaitForSeconds(1.5f);
    }

    
    private void DetectFall()
    {
        RaycastHit hitInfo;

        Ray ray = new Ray(this.transform.position + (direction * this.transform.localScale.x * 2), Vector3.down);

        if(Physics.Raycast(ray, out hitInfo, 0.05f))
        {
            if(hitInfo.transform.name != "Floor")
            {
                if(isMoving) return;

                ran.random = UnityEngine.Random.Range(0, 4);
            }
        }
    }
}
