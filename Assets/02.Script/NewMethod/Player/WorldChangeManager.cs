using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
public class WorldChangeManager : MonoBehaviour
{
    
    
    void Start()
    {
//        Debug.Log("A");
        Transform player = Instantiate(GameData.Instance.currentWorld).transform;
        player.parent = this.transform;
        player.localPosition = new Vector3(0,0,0);
        player.localRotation = this.transform.localRotation;
        player.localScale = new Vector3(0.0044f,0.0044f,0.0044f);

        DetectArea[] cubes = player.GetComponentsInChildren<DetectArea>(true);
        foreach(var cube in cubes)
        {
            cube.enabled = true;
            cube.transform.Find("ZoneBlue").gameObject.SetActive(false);
        }

        if (GameData.Instance.currentGame == 1)
        {
            OpenBox[] boxes = player.GetComponentsInChildren<OpenBox>(true);
            foreach(var box in boxes)
            {
                box.enabled = true;
            }
        }

        Transform surfaces = player.Find("Surfaces");
        surfaces.Find("MoveArea").gameObject.SetActive(true);
        surfaces.Find("CameraRayDetectArea").gameObject.SetActive(true);

        if(GameData.Instance.currentGame == 0)
        {
            surfaces.Find("MoveArea").Find("Player").GetComponent<FindKeyPlayerMoveManager>().enabled=true;

            KeyObjectBehaviour[] keys = player.GetComponentsInChildren<KeyObjectBehaviour>(true);
            foreach(var key in keys)
            {
                key.gameObject.SetActive(true);
            }
        }
        else if (GameData.Instance.currentGame == 1)
        {
            surfaces.Find("MoveArea").Find("Player").GetComponent<FindLoadPlayerMoveManager2>().enabled=true;
            player.GetComponentsInChildren<DestinationManager>(true)[0].gameObject.SetActive(true);
        }
        

        //GetComponent<DefaultObserverEventHandler>().OnTargetFound = a();
    }

    // public UnityEvent a()
    // {

    // }


}
