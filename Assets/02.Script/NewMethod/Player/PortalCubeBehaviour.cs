using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class PortalCubeBehaviour : MonoBehaviour
{
    private Animator anim;
    private AnimationClip animClip;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //애니메이션 역재생을 위한 초기화
        anim = GetComponent<Animator>();
        animClip = anim.GetCurrentAnimatorClipInfo(0)[0].clip;


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
                anim.StartPlayback();
                this.gameObject.SetActive(false);
                break;

        }
    }

    void Update()
    {
        
    }
}
