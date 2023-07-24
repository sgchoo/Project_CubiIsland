using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActARCam_UI : MonoBehaviour
{

    public GameObject target;
    public GameObject UICamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PanelLoading_UI.ActAR == true)
        {
            ActImageTarget();
        }
    }

    private void ActImageTarget()
    {
        // 이미지 타겟 켜기
        // XROrigin.SetActive(true);
        // XRSettings.enabled = true;
        target.SetActive(true);
        if(UICamera != null)
        {
            UICamera.SetActive(false);
        }
        
    }
}
