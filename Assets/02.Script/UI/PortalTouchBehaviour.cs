using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalTouchBehaviour : MonoBehaviour
{    
    public Transform character;
    public Transform world;
    
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("STart");
        // Transform parent = GameObject.Find("CubiWorld_0711").transform.Find("InsideObject").transform.Find("TouchObject");
        // character = parent.Find("Character");
        // world = parent.Find("WorldMap");
        // Debug.Log("NAME : " + character.name + " " + world.name);
    }

    private bool isDetect = false;
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("UpdateSTart");
        // if(!isDetect && GameObject.Find("CubiWorld_0711") != null)
        // {
        //     Debug.Log("Update");
        //     Transform parent = GameObject.Find("CubiWorld_0711").transform.Find("InsideObject").transform.Find("TouchObject");
        //     character = parent.Find("Character").transform;
        //     world = parent.Find("WorldMap").transform;
        //     Debug.Log("NAME2 : " + character.name + " " + world.name);
        //     isDetect = true;
        // }
        

        // 한 번만 누를 때 활성화돰
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
             if (EventSystem.current.IsPointerOverGameObject())
            {
                GameObject uiObj = EventSystem.current.currentSelectedGameObject;
                if(uiObj != null)
                {   
                    Debug.Log("PortalTouchBehaviour.cs::"+uiObj.name);
                    return;
                }
                
            }

            if(GameData.Instance.tutorialPlaza && !TutorialScriptController.interactionActive) return;
            //if(tutorial)

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.name == character.name)
                {
                    if(GameData.Instance.tutorial && TutorialScriptController.tutorialCount == 2) return;
                    SceneManager.LoadScene(KeyStore.characterSelectScene);
                    Handheld.Vibrate();
                }
                else if (hit.collider.name == world.name)
                {
                    if(GameData.Instance.tutorial && TutorialScriptController.tutorialCount == 1) return;
                    SceneManager.LoadScene(KeyStore.worldSelectScene);
                    Handheld.Vibrate();
                }
            }
        }    
    }
    
}
