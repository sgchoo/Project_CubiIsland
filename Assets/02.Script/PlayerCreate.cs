using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//<summary>
//이미지 인식을 하게되면
//큐브 위 지정된 위치에
//Player 생성
// </summary>

public class PlayerCreate : MonoBehaviour
{
    public GameObject player;

    Quaternion originRot;

    private void Awake() 
    {
        MeshRenderer[] meshs = this.GetComponentsInChildren<MeshRenderer>();

        for(int i = 0; i < meshs.Length; i++) 
        {
            meshs[i].enabled = true;
        }

        BoxCollider[] colls = this.GetComponentsInChildren<BoxCollider>();

        for(int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = true;
        }
    }

    private void Update() 
    {
        MeshRenderer[] meshs = this.GetComponentsInChildren<MeshRenderer>();

        for(int i = 0; i < meshs.Length; i++) 
        {
            meshs[i].enabled = true;
        }

        BoxCollider[] colls = this.GetComponentsInChildren<BoxCollider>();

        for(int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = true;
        }

        this.transform.position = this.transform.root.position;
    }

    public void CreatePlayer()
    {
        this.gameObject.SetActive(true);
        player.SetActive(true);
    }

    public void TransformLocate()
    {
        // this.transform.localPosition = imageTr.position;
        // this.transform.localRotation = imageTr.rotation;
    }
}
