using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPortal : MonoBehaviour
{
    private GameObject portal;

    private void Awake() 
    {
        portal = GameObject.FindGameObjectWithTag("World");
    }

    private void OnEnable() 
    {
        portal.transform.position = TouchPortalPanel.anchorPos;
    }
}
