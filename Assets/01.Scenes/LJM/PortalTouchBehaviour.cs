using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalTouchBehaviour : MonoBehaviour
{    
    public Transform character;
    public Transform world;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 한 번만 누를 때 활성화돰
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.name == character.name)
                {
                    SceneManager.LoadScene("05.ChangeCharScene");
                }
                else if (hit.collider.name == world.name)
                {
                    SceneManager.LoadScene("06.ChangeMapScene");
                }
            }
        }    
    }
}
