using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVector : MonoBehaviour
{
    private Vector3 ScreenCenter;
    public static Axis axis;

    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.localRotation);

        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 0.5f);
            if (hit.collider.gameObject.name == "Cube")
            {
                axis = hit.collider.gameObject.GetComponent<DetectArea>().GetChangeAxis();
                //Debug.Log("axis : " + axis);

                Vector3 relativePosition = hit.collider.gameObject.transform.InverseTransformPoint(transform.position);

                // 상대 위치를 이용하여 y 축 회전값을 계산합니다.
                float rotationY = Mathf.Atan2(relativePosition.x, relativePosition.z) * Mathf.Rad2Deg;
                Debug.Log("Y Rotation relative to A: " + rotationY);
            }
        }

    }
}
