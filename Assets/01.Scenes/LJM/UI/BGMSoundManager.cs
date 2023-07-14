using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip titleBGM;
    public AudioClip plazaBGM;
    public AudioClip gameBGM;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        bgmPlay(titleBGM);
    }

    public void bgmPlay(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string name = scene.name;
        switch(name)
        {
            case KeyStore.titleScene : 
            case KeyStore.lobbyScene : 
                bgmPlay(titleBGM); break;

            case KeyStore.createPlazaScene : 
            case KeyStore.plazaScene : 
            case KeyStore.characterSelectScene : 
            case KeyStore.worldSelectScene : 
            case KeyStore.startCheckScene : 
                bgmPlay(plazaBGM); break;

            case KeyStore.findKeyScene :
            case KeyStore.findLoadScene :
                bgmPlay(gameBGM); break;

        }
    }

    
}
