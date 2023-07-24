using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDirectionManager : MonoBehaviour
{

    public static Direction direction = Direction.none;

    // Start is called before the first frame update
    void Start()
    {
        // Vector3 viewportPoint = new Vector3(0.5f, 2f / 3f, 0f); // 화면 세로의 상단 부분에 해당하는 뷰포트 좌표 (0.5, 2/3, 0)
        // Ray ray = Camera.main.ViewportPointToRay(viewportPoint);

        // RectTransform imageRectTransform = imageObject.GetComponent<RectTransform>();
        // imageRectTransform.anchoredPosition = Camera.main.ViewportToScreenPoint(ray.origin);
    }

    // Update is called once per frame
    void Update()
    {
        if(RayForDirection() == Direction.none)
        {
            //ColorSet(new Color(255,255,255));
            SetActImage(false);
        }
        else 
        {
            //ColorSet(new Color(0,255,0));
            SetActImage(true);

        }
    }

    public GameObject noneAct;
    public GameObject act;

    public Direction RayForDirection()
    {
        //Ray ray = new Ray(this.transform.position, this.transform.forward);
        Vector3 viewportPoint = new Vector3(0.5f, 2f / 3f, 0f); // 화면 세로의 상단 부분에 해당하는 뷰포트 좌표 (0.5, 2/3, 0)
        Ray ray = Camera.main.ViewportPointToRay(viewportPoint);

        // RectTransform imageRectTransform = imageObject.GetComponent<RectTransform>();
        // imageRectTransform.localPosition = Camera.main.ViewportToScreenPoint(ray.origin);


        RaycastHit hit;

        direction = Direction.none;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider == null) return Direction.none;
            
            switch(hit.collider.transform.name)
            {
                case "forward"  : direction = Direction.forward; break;
                case "right"    : direction = Direction.right;   break;
                case "back"     : direction = Direction.back;    break;
                case "left"     : direction = Direction.left;    break;
                default :         direction = Direction.none;    break;
            }

        }

        return direction;

    }

    private void ColorSet(Color color)
    {
        noneAct.GetComponent<Image>().color = color;
    }

    private void SetActImage(bool actFlag)
    {
        noneAct.SetActive(!actFlag);
        act.SetActive(actFlag);
    }

    private void OnDrawGizmosSelected() 
    {
        Ray gizmoRay = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hitInfo;

        if(Physics.Raycast(gizmoRay, out hitInfo))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hitInfo.point, 0.003f);
        }
    }
}
