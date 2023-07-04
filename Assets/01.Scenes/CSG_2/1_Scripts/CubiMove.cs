
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubiDirection
{
    public int directionNum = -2;
}

public class CubiMove : MonoBehaviour
{
    CubiDirection cubiDir = new CubiDirection();
    
    [SerializeField] int rollSpeed = 1;
    bool isMoving;

    private void Update()
    {
        CubiRolling();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.name == "Floor")
        {
            this.transform.eulerAngles = Vector3.zero;
        }
    }
    void RandomDirection()
    {
        cubiDir.directionNum = UnityEngine.Random.Range(-1, 4);
    }

    private void CubiRolling()
    {
        if(isMoving) return;

        switch(cubiDir.directionNum)
        {
            case -1:
                RollDirection(Vector3.left);
                break;

            case 0:
                //RollDirection(Vector3.zero);
                break;

            case 1:
                RollDirection(Vector3.forward);
                break;

            case 2:
                RollDirection(Vector3.right);
                break;

            case 3:
                RollDirection(Vector3.back);
                break;
        }
    }

    private void RollDirection(Vector3 dir)
    {
        var anchor = this.transform.localPosition + (Vector3.down + dir) * 0.02f;
        var axis = Vector3.Cross(Vector3.up, dir);
        StartCoroutine(Rolling(anchor, axis));
    }

    IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;

        for(int i = 0; i < (90 / rollSpeed); i++)
        {
            this.transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }
}
