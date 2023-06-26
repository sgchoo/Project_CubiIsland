using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;

public class TM : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float moveCnt;
    [SerializeField] private float rotateCnt;

    public Ease ease;
    private void Start() 
    {
        this.transform.position = player.position + (Vector3.down + Vector3.forward);

        DOTween.Init();

        DOTween.SetTweensCapacity(1250, 10);

        StartCoroutine(RollCube());
    }


    IEnumerator RollCube()
    {
        player.SetParent(this.transform);

        if(moveCnt == 4)
        {
            transform.DORotate(new Vector3(this.transform.eulerAngles.x + 180, 0, 0), 0.5f).SetEase(ease).SetLoops(1);
            rotateCnt++;
            moveCnt = 0;
        }

        else
        {
            transform.DORotate(new Vector3(this.transform.eulerAngles.x + 90, 0, 0), 0.5f).SetEase(ease).SetLoops(1);
        }

        yield return new WaitForSeconds(0.5f);

        player.parent = null;

        this.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x - 90, 0, 0);

        yield return new WaitForSeconds(0.5f);

        this.transform.position = player.position + new Vector3(0, -1, 1);

        moveCnt += 1;

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(RollCube());
    }
}
