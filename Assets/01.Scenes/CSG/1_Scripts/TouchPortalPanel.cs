using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchPortalPanel : MonoBehaviour
{
    private ARRaycastManager raycastMgr;
    private ARAnchorManager anchorMgr;
    private ARPlaneManager planeMgr;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<ARAnchor> anchors = new List<ARAnchor>();
    [SerializeField] private Camera arCamera;

    public Transform point;
    public GameObject checkUI;
    public GameObject portal;
    public static Vector3 anchorPos;
    void Start() 
    {
        checkUI.SetActive(false);
        point.gameObject.SetActive(false);
        raycastMgr = GetComponent<ARRaycastManager>();
        anchorMgr = GetComponent<ARAnchorManager>();
        planeMgr = GetComponent<ARPlaneManager>();

        if(GameData.Instance.plazaWorld != null)
        {
            Destroy(GameData.Instance.plazaWorld);
            GameData.Instance.plazaWorld = null;
        }

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
            PortalDetectTextBehaviour.mode = 1;
            point.gameObject.SetActive(true);
            point.transform.position = hits[0].pose.position;

        }

        else
        {
            PortalDetectTextBehaviour.mode = 0;
            point.gameObject.SetActive(false);
        }
    }

    private Vector3 hitPos;

    public void EnterBtn()
    {
        checkUI.SetActive(true);
        hitPos = point.transform.position;
    }

    public void CreateBtn()
    {
        var anchor = anchorMgr.AttachAnchor(planeMgr.GetPlane(hits[0].trackableId), hits[0].pose);
        anchor.destroyOnRemoval = false;
        anchorPos = anchor.transform.position;

        GameObject gate = Instantiate(portal);
        GameData.Instance.plazaWorld = gate;
        DontDestroyOnLoad(gate);
        gate.transform.position = hitPos;
        gate.transform.rotation = Quaternion.Euler(0, 180, 0);
        
        checkUI.SetActive(false);

        Invoke("DelayMove", 0.1f);
    }

    public void DelayMove()
    {
        SceneManager.LoadScene(KeyStore.plazaScene);
    }

    public void BackBtn()
    {
        checkUI.SetActive(false);
    }

}
