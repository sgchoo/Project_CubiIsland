using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTouchRaycast : MonoBehaviour
{
    public GameObject target;
    public TouchPortalPanel panel;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null && hit.collider.gameObject == target)
            {
                panel.EnterBtn();
            }
        }   
    }
}
