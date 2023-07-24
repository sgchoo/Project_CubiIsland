using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSkipFunc : MonoBehaviour
{
    
    public void FindKeySkip()
    {
        SceneManager.LoadScene(KeyStore.findKeyScene);
    }

    public void FindRoadSkip()
    {
        SceneManager.LoadScene(KeyStore.findLoadScene);
    }
}
