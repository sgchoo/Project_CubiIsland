using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCubeBehaviour : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {   
        string name = scene.name;
        switch(name)
        {
            case KeyStore.createPlazaScene : 
            case KeyStore.plazaScene : 
                this.gameObject.SetActive(true);
                break;

            case KeyStore.titleScene : 
            case KeyStore.lobbyScene : 
            case KeyStore.characterSelectScene : 
            case KeyStore.worldSelectScene : 
            case KeyStore.startCheckScene : 
            case KeyStore.findKeyScene :
            case KeyStore.findLoadScene :
                this.gameObject.SetActive(false);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
