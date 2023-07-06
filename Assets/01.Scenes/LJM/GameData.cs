using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance = null;
    public static GameData Instance
    {
        get
        {
            if (null == instance) { return null; }
            return instance;
        }
    }

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }    
    }

    public GameObject currentCharacter;
    public GameObject currentWorld;

}
