using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ranValue
{
    public int random;
}

public class CubiMove : MonoBehaviour
{
    public Transform cubiDirection;
    ranValue ranNum = new ranValue();
    private bool isMoving;
    private int hAngle;
    private int vAngle;
    private int rot;
    private float curTime;

    private void Start() 
    {
        RandomValue();

        DOTween.Init();
        DOTween.SetTweensCapacity(50000, 50);
    }

    private void Update() 
    {
        //DetectFall();
        if(!isMoving) return;

        Roll(cubiDirection.forward);

        curTime += Time.deltaTime;
        if(curTime > 0.9f)
        {
            if(ranNum.random == 0) hAngle += 90;
            else if(ranNum.random == 1) hAngle -= 90;
            else if(ranNum.random == 2) hAngle += 90;
            else if(ranNum.random == 3) hAngle -= 90;
            curTime = 0;
        }
    }

    private void Roll(Vector3 dir)
    {
        transform.DOMove(dir * this.transform.localScale.x, 2.0f).SetRelative().SetEase(Ease.Unset).SetLoops(1);


        transform.DOLocalRotate(new Vector3(hAngle, 0, this.transform.localRotation.z), 1.0f).SetEase(Ease.Unset).SetLoops(1);
        
        
        cubiDirection.localRotation = Quaternion.Euler(0, rot, 0);
    }

    private void RandomValue()
    {
        ranNum.random = UnityEngine.Random.Range(0, 4);
        
        switch(ranNum.random)
        {
            case 0:
                rot += 90;
                break;

            case 1:
                rot -= 90;
                break;

            case 2:
                rot += 90;
                break;

            case 3:
                rot -= 90;
                break;
        }

        Invoke("RandomValue", 5.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "Floor")
        {
            StartCoroutine(ChangeRot());
        }
    }

    public IEnumerator ChangeRot()
    {
        yield return new WaitForSeconds(1.0f);

        this.transform.eulerAngles = Vector3.zero;
        cubiDirection.eulerAngles = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        isMoving = true;
    }

    private void DetectFall()
    {
        RaycastHit hitInfo;

        Ray ray = new Ray(this.transform.position + (cubiDirection.forward * this.transform.localScale.x * 2), Vector3.down);

        if(Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.transform.name != "Floor")
            {
                if(!isMoving) return;
                cubiDirection.localRotation = Quaternion.Euler(0, -rot, 0);
            }
        }
    }
}
