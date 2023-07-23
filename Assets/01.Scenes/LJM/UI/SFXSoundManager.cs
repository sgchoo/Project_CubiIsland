using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundManager : MonoBehaviour
{
    private static SFXSoundManager instance = null;
    public static SFXSoundManager Instance
    {
        get
        {
            if (null == instance) { return null; }
            return instance;
        }
    }

    private AudioSource audioSource;
    public AudioClip touchSound;
    public AudioClip[] landingSounds;
    public AudioClip rollSound;
    public AudioClip uiPanelSound;
    public AudioClip itemSound;
    public AudioClip tutorialClear;
    public AudioClip mainGameClear;

    public List<AudioClip> cubiTutoPlazaSound1;
    public List<AudioClip> cubiTutoPlazaSound2;
    public List<AudioClip> cubiTutoPlazaSound3;
    public static int plazaIdx = 0;

    public List<AudioClip> cubiTutoFindKeySound;
    public List<AudioClip> cubiTutoFindRoadSound;

    public void TutorialFindKeyPlay(int idx)
    {
        audioSource.Stop();
        audioSource.PlayOneShot( cubiTutoFindKeySound[idx] );
    }
    
    public void TutorialFindRoadPlay(int idx)
    {
        audioSource.Stop();
        audioSource.PlayOneShot( cubiTutoFindRoadSound[idx] );
    }

    public void TutorialPlazaPlay()
    {
        if(TutorialScriptController.tutorialCount == 0)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(cubiTutoPlazaSound1[plazaIdx++]);
        }
        else if(TutorialScriptController.tutorialCount == 1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(cubiTutoPlazaSound2[plazaIdx++]);
        }
        else if(TutorialScriptController.tutorialCount == 2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(cubiTutoPlazaSound3[plazaIdx++]);
        }
    }

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    public void playTouchSound()
    {
        audioSource.PlayOneShot(touchSound);
    }

    public void PlayLandingSound()
    {
        if(GameData.Instance.currentWorld.name == "Map01_Forest")
        {
            audioSource.PlayOneShot(landingSounds[0]);
        }
        else if(GameData.Instance.currentWorld.name == "Map02_Snow")
        {
            audioSource.PlayOneShot(landingSounds[1]);
        }
    }

    public void PlayRollSound()
    {
        audioSource.PlayOneShot(rollSound);
    }

    public void ActiveUIPanelSound()
    {
        audioSource.PlayOneShot(uiPanelSound);
    }

    public void GetItemSound()
    {
        audioSource.PlayOneShot(itemSound);   
    }

    public void TutorialClearSound()
    {
        audioSource.PlayOneShot(tutorialClear);
    }

    public void MainGameClearSound()
    {
        audioSource.PlayOneShot(mainGameClear);
    }
}
