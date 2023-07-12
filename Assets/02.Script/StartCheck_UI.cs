using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCheck_UI : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PanelLoad;

    // Start is called before the first frame update
    void Start()
    {
        if(Canvas != null)
        {
            Canvas.SetActive(true);
        }
        if(PanelLoad != null)
        {
            PanelLoad.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
