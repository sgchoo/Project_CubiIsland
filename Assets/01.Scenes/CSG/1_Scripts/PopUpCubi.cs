using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUpCubi : MonoBehaviour
{
    public Ease easeY;
    public Ease easeZ;

    public Transform playerPrefab;
    public Transform[] players;
    private FindLoadPlayerMoveManager rollCS;
    private static bool isPopUp;

    private void Awake() 
    {
        rollCS = this.transform.GetChild(0).GetComponent<FindLoadPlayerMoveManager>();
    }

    private void Start() 
    {
        if(!isPopUp)
        {
            if(this.transform == players[0])      StartCoroutine(PopUp(0.21f, 0.4f));
            if(this.transform == players[1])      StartCoroutine(PopUp(0.21f, 0.4f));
            if(this.transform == players[2])      StartCoroutine(PopUp(0.21f, -0.4f)); 
            if(this.transform == players[3])      StartCoroutine(PopUp(0.21f, -0.4f)); 
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.name == "Portal")
        {
            playerPrefab.gameObject.layer = 0;
        }
    }

    IEnumerator PopUp(float moveY, float moveZ)
    {
        yield return new WaitForSeconds(1.5f);

        transform.DOMoveY(moveY, 1.5f).SetEase(easeY).SetRelative();
        transform.DOMoveZ(moveZ, 1.5f).SetEase(easeZ).SetRelative();

        yield return new WaitForSeconds(2.2f);

        rollCS.enabled = true;
        isPopUp = true;
    }
}
