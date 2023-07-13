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



    // 사운드 관련 키
    public const string sfxMuteKey = "SFXMute";
    public const string bgmMuteKey = "BGMMute";
    public const string sfxVolumeKey = "SFXVolume";
    public const string bgmVolumeKey = "BGMVolume";

    // 플레이 관련 키
    public const string CHARACTER_KEY = "character";
    public const string WORLDMAP_KEY = "world";


    // 튜토리얼 관련 키
    public const string tutorialKey = "Tutorial";

    public const string tutorialPlaza = "01.TutorialPlazaScene";
    public const string tutorialStartCheckFirst = "02.TutorialStartCheckScene";
    public const string tutorialLoadSceneFirst = "03.TutorialLoadScene";
    public const string tutorialFindKeyGame = "04.TutorialFindKeyScene";
    public const string tutorialPlazaSecond = "05.TutorialPlazaScene";
    public const string tutorialChangeChar = "06.TutorialChangeCharScene";
    public const string tutorialStartCheckSecond = "07.TutorialStartCheckScene";
    public const string tutorialLoadSceneSecond= "08.TutorialLoadScene";
    public const string tutorialFindLoadGame = "09.TutorialFindLoadScene";
    public const string tutorialPlazaThird = "10.TutorialPlazaScene";
    public const string tutorialChangeWorld = "11.TutorialChangeMapScene";
    public const string tutorialPlazaFourth = "12.TutorialPlazaScene";
}
