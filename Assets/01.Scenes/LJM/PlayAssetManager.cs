using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAssetManager : MonoBehaviour
{
    public Transform character;
    public Transform world;

    private bool isSet = false;

    private void OnEnable() 
    {
        isSet = false;    
    }
    private void Start() 
    {
        isSet = false;    
    }
    private void Update() 
    {
        SetAsset();
    }

    public void SetAsset()
    {
        Debug.Log("인식 중 . . " + GameData.Instance.currentCharacter.name + " " + GameData.Instance.currentWorld.name);
        if (!isSet && UIController2_UI.instance.PlayerAssetCheck())
        {
            Debug.Log("인식완료");
            isSet = true;
            Transform currentCharacter = Instantiate(GameData.Instance.currentCharacter).transform;
            currentCharacter.parent = character;
            currentCharacter.position = character.position;
            currentCharacter.localRotation = Quaternion.Euler(0,0,0);
            currentCharacter.localScale = new Vector3(0.4f,0.4f,0.4f);
            currentCharacter.gameObject.layer = 29;

            Transform currentWorld = Instantiate(GameData.Instance.currentWorld).transform;
            currentWorld.parent = world;
            currentWorld.position = world.position;
            currentWorld.localRotation = Quaternion.Euler(0,0,0);
            currentWorld.localScale = new Vector3(0.08f,0.08f,0.08f);
            currentWorld.gameObject.layer = 29;
            Debug.Log("인식완료");
        }    
    }
}
