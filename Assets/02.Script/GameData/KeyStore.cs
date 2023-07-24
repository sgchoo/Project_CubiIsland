using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyStore
{
    public const string titleScene = "01.TitleScene";
    public const string lobbyScene = "02.LobbyScene";
    public const string createPlazaScene = "03.CreatePlazaScene";
    public const string plazaScene = "04.PlazaScene";
    public const string characterSelectScene = "05.ChangeCharScene";
    public const string worldSelectScene = "06.ChangeMapScene";
    public const string startCheckScene = "07.StartCheckScene";
    public const string loadScene = "07_2.LoadScene";
    public const string findKeyScene = "08.FindKeyScene";
    public const string findLoadScene = "09.FindLoadScene";
    public const string optionScene = "99.OptionScene";


    // etc
    public const string lockTag = "locked";

    // 사운드 관련 키
    public const string sfxMuteKey = "SFXMute";
    public const string bgmMuteKey = "BGMMute";
    public const string sfxVolumeKey = "SFXVolume";
    public const string bgmVolumeKey = "BGMVolume";

    // 플레이 관련 키
    public const string CHARACTER_KEY = "character";
    public const string WORLDMAP_KEY = "world";
    public const string CHARACTER_UNLOCK_INDEX = "char_unlock";
    public const string WORLD_UNLOCK_INDEX = "world_unlock";


    // 튜토리얼 관련 키
    public const string tutorialKey = "Tutorial";
    public const string TUTORIAL_PLAZA_KEY = "tutorial_plaza";
    public const string TUTORIAL_CHARACTER_KEY = "tutorial_character";
    public const string TUTORIAL_MAP_KEY = "tutorial_map";
    public const string TUTORIAL_FIND_KEYGAME_KEY = "tutorial_find_key";
    public const string TUTORIAL_FIND_ROAD_KEY = "tutorial_find_road";

    public const string tutorialPlaza = "01.TutorialPlazaScene";
    public const string tutorialChangeChar = "02.TutorialChangeCharScene";
    public const string tutorialFindKeyGame = "03.TutorialFindKeyScene";
    public const string tutorialFindRoadGame = "04.TutorialFindRoadScene";
}
