using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCubeManager : MonoBehaviour
{
    public GameObject loadingScene;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PanelLoading_UI.ActAR)
        {
            Debug.Log("실행");
            target.SetActive(true);
            this.enabled = false;
        }
    }
}
