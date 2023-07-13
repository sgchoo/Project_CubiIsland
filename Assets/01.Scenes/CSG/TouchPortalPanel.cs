using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchPortalPanel : MonoBehaviour
{
    public Transform placeObject;

    private ARRaycastManager raycastMgr; 

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool touched = false;

    private GameObject SelectedObj;

    [SerializeField] private Camera arCamera;

    public Transform point;
    public GameObject checkOption;
    public GameObject portal;

    void Start() 
    {
        checkOption.SetActive(false);
        point.gameObject.SetActive(false);
        // AR Raycast Manager 초기화
        raycastMgr = GetComponent<ARRaycastManager>();
    }

    private void Update() 
    {
        RayPointer();
    }

    private void RayPointer()
    {
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        if(raycastMgr.Raycast(screenSize, hits, TrackableType.PlaneWithinPolygon))
        {
            point.gameObject.SetActive(true);
            point.transform.position = hits[0].pose.position;
        }

        else
        {
            point.gameObject.SetActive(false);
        }
    }

    public void EnterBtn()
    {
        checkOption.SetActive(true);
    }

    public void CreateBtn()
    {
        GameObject gate = Instantiate(portal);
        gate.transform.position = hits[0].pose.position;
        gate.transform.rotation = Quaternion.identity;
    }

    public void BackBtn()
    {
        checkOption.SetActive(false);
    }

    //// 터치 & 드래그로 Portal 생성
    // void Update() 
    // { 
    //     if (Input.touchCount == 0) return; 

    //     Touch touch = Input.GetTouch(0); 

    //     //터치 시작시
    //     if (touch.phase == TouchPhase.Began) 
    //     {
    //         Ray ray;

    //         RaycastHit hitobj;

    //         ray = arCamera.ScreenPointToRay(touch.position);

    //         //Ray를 통한 오브젝트 인식
    //         if(Physics.Raycast(ray, out hitobj))
    //         {
    //             //터치한 곳에 오브젝트 이름이 Cube를 포함하면
    //             if (hitobj.collider.name.Contains("PortalPanel"))
    //             {
    //                 //그 오브젝트를 SelectObj에 놓는다
    //                 SelectedObj = hitobj.collider.gameObject;
    //                 touched = true;
    //             }
    //         }
    //     } 

    //     //터치가 끝나면 터치 끝.
    //     if(touch.phase == TouchPhase.Ended)
    //     {
    //         touched = false;
    //         placeObject.GetChild(0).gameObject.SetActive(true);
    //     }

    //     if (raycastMgr.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
    //     {
    //         //터치 시 해당 오브젝트 위치 초기화
    //         if (touched)
    //         {
    //             SelectedObj.transform.position = hits[0].pose.position;
    //         }
    //     }
    // }
}
