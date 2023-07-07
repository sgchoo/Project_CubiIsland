using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAssetManager : MonoBehaviour
{
    public Transform character;
    public Transform world;

    public static bool isSet = false;

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
        if (!isSet)
        {
            CheckPrevObj();
            SetAsset();
        }
    }

    public void CheckPrevObj()
    {
        int charCount = character.childCount;
        DestroyChild(character);
        DestroyChild(world);
    }
    
    public void DestroyChild(Transform target)
    {
        Debug.Log("D : " + target.name + " 자식 객체 삭제 대기");
        int count = target.childCount;
        if ( count != 0 )
        {
            for(int idx = 0; idx < count; idx++)
            {
                Debug.Log("D : " + target.GetChild(idx).name + " 삭제");
                Destroy(target.GetChild(idx));
            }
        }
    }

    public void SetAsset()
    {
        Debug.Log("D : " + "에셋설정시작");
        if (UIController2_UI.instance.PlayerAssetCheck())
        {
            Debug.Log("D : " + "실행됨" + GameData.Instance.currentCharacter.name);
            isSet = true;
            Transform currentCharacter = Instantiate(GameData.Instance.currentCharacter).transform;
            // currentCharacter.parent = character;
            // currentCharacter.position = character.position;
            // currentCharacter.localRotation = Quaternion.Euler(0,0,0);
            // currentCharacter.localScale = new Vector3(0.4f,0.4f,0.4f);
            // currentCharacter.gameObject.layer = 29;
            Settnigs(currentCharacter, character, new Vector3(0.4f,0.4f,0.4f));

            Transform currentWorld = Instantiate(GameData.Instance.currentWorld).transform;
            // currentWorld.parent = world;
            // currentWorld.position = world.position;
            // currentWorld.localRotation = Quaternion.Euler(0,0,0);
            // currentWorld.localScale = new Vector3(0.08f,0.08f,0.08f);
            // currentWorld.gameObject.layer = 29;
            Settnigs(currentWorld, world, new Vector3(0.08f,0.08f,0.08f));

        }    
    }

    public void Settnigs(Transform obj, Transform parent, Vector3 localScale)
    {
        obj.parent = parent;
        obj.position = parent.position;
        obj.localRotation = Quaternion.Euler(0,0,0);
        obj.localScale = localScale;
        obj.gameObject.layer = 29;
    }
}
