using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameData.Instance.plazaWorld != null)
        {
            GameData.Instance.plazaWorld.SetActive(false);
        }
        
    }

}
