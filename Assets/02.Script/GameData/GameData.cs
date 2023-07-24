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
            DontDestroyOnLoad(gameObject);
        }    
        else 
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable() 
    {
        
    }

    // 지정했던 캐릭터와 월드맵을 저장해둘 변수
    public GameObject currentCharacter;
    public GameObject currentWorld;

    // sfx, bgm을 저장해둘 변수
    public Sound sfx;
    public Sound bgm;

    public AudioSource bgmAudio;
    public AudioSource sfxAudio;

    // current Game => 0 : FindKeyGame
    // current Game => 1 : FindLoadGame
    public int currentGame;

    public GameObject plazaWorld;

    public GameObject characterPref;
    public GameObject mapPref;
    public List<GameObject> characterLockList;
    public List<GameObject> mapLockList;
    public int characterUnLockIdx;
    public int worldUnLockIdx;
    
    public bool tutorial = false;
    public bool tutorialPlaza = false;
    public bool tutorialCharacter = false;
    public bool tutorialMap = false;
    public bool tutorialFindKey = false;
    public bool tutorialFindRoad = false;
    

    private void Start() 
    {
        characterLockList = new List<GameObject>();
        mapLockList = new List<GameObject>();
        characterUnLockIdx = 0;
        worldUnLockIdx = 0;
        currentGame = 0;

        SetTutorial();
        // tutorial = false;

        if(PlayerPrefs.HasKey(KeyStore.CHARACTER_UNLOCK_INDEX))
        {
            characterUnLockIdx = PlayerPrefs.GetInt(KeyStore.CHARACTER_UNLOCK_INDEX, 0);
        }
        if(PlayerPrefs.HasKey(KeyStore.WORLD_UNLOCK_INDEX))
        {
            worldUnLockIdx = PlayerPrefs.GetInt(KeyStore.WORLD_UNLOCK_INDEX, 0);
        }

        LockListUpdate();

        SetSound();

        SetCharacter();
        //Debug.Log("GAMEDATA :: " + currentCharacter.name);
        SetWorld();
        //Debug.Log("GAMEDATA :: " + currentWorld.name);
        
    }

    private void SetPlayAsset()
    {
        
    }

    private void SetCharacter()
    {
        SetResource(KeyStore.CHARACTER_KEY, ref currentCharacter);
    }

    private void SetWorld()
    {
        SetResource(KeyStore.WORLDMAP_KEY, ref currentWorld);
    }

    private void SetResource(string key, ref GameObject target)
    {
        if(PlayerPrefs.HasKey(key))
        {
            string data = PlayerPrefs.GetString(key);
            Debug.Log("GAMEDATA :: " + data);
            target = Resources.Load<GameObject>(data);
        }
    }

    private void SetTutorial()
    {
        tutorial =          PlayerPrefs.HasKey(KeyStore.tutorialKey)                ? false : true;
        tutorialPlaza =     PlayerPrefs.HasKey(KeyStore.TUTORIAL_PLAZA_KEY)         ? false : true;
        tutorialCharacter = PlayerPrefs.HasKey(KeyStore.TUTORIAL_CHARACTER_KEY)     ? false : true;
        tutorialMap =       PlayerPrefs.HasKey(KeyStore.TUTORIAL_MAP_KEY)           ? false : true;        
        tutorialFindKey =   PlayerPrefs.HasKey(KeyStore.TUTORIAL_FIND_KEYGAME_KEY)  ? false : true;        
        tutorialFindRoad =  PlayerPrefs.HasKey(KeyStore.TUTORIAL_FIND_ROAD_KEY)     ? false : true;        
    }

    public void LockListUpdate()
    {
        CheckCharacterLock();
        CheckMapLock();
    }

    public void CheckCharacterLock()
    {
        lockCheck(characterPref, ref characterLockList, characterUnLockIdx);
    }

    public void CheckMapLock()
    {
        lockCheck(mapPref, ref mapLockList, worldUnLockIdx);
    }

    public void lockCheck(GameObject pref, ref List<GameObject> list, int unlockIdx)
    {
        int count = pref.transform.childCount;
        for(int idx = 0; idx < count; idx++)
        {
            Transform target = pref.transform.GetChild(idx).transform;
            if(target.Find(KeyStore.lockTag).gameObject.activeSelf)
            {
                if(unlockIdx-- > 0) continue;
                list.Add(target.gameObject);
            }
        }
    }

    private void SetSound()
    {
        sfx = new Sound();
        bgm = new Sound();
        sfx.LoadSound(KeyStore.sfxMuteKey, KeyStore.sfxVolumeKey);
        bgm.LoadSound(KeyStore.bgmMuteKey, KeyStore.bgmVolumeKey);

        SetAudioVolume();
    }

    public void SetAudioVolume()
    {
        bgmAudio.volume = bgm.mute ? 0 : bgm.volume / 100f;
        sfxAudio.volume = sfx.mute ? 0 : sfx.volume / 100f;
    }
    
    public bool CheckAssets()
    {
        Debug.Log(currentCharacter != null && currentWorld != null);
        return currentCharacter != null && currentWorld != null;
    }
}