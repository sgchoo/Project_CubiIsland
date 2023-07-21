using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAssetManager : MonoBehaviour
{
    public Transform character;
    public Transform world;
    public int targetLayer;

    public static bool isSet = false;

    private void OnEnable() 
    {
        isSet = false;    
    }
    private void Start() 
    {
        isSet = false;    
        targetLayer = 29;
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
                Destroy(target.GetChild(idx).gameObject);
            }
        }
    }

    public void SetAsset()
    {
        Debug.Log("D : " + "에셋설정시작");
        if (GameData.Instance.CheckAssets())
        {
            Debug.Log("D : " + "실행됨" + GameData.Instance.currentCharacter.name);
            isSet = true;
            Transform currentCharacter = Instantiate(GameData.Instance.currentCharacter).transform;
            // currentCharacter.parent = character;
            // currentCharacter.position = character.position;
            // currentCharacter.localRotation = Quaternion.Euler(0,0,0);
            // currentCharacter.localScale = new Vector3(0.4f,0.4f,0.4f);
            // currentCharacter.gameObject.layer = 29;
            Settnigs(currentCharacter, character, new Vector3(0.33f,0.33f,0.33f));

            Debug.Log("D : " + "실행됨" + GameData.Instance.currentWorld.name);
            Transform currentWorld = Instantiate(GameData.Instance.currentWorld).transform;
            // currentWorld.parent = world;
            // currentWorld.position = world.position;
            // currentWorld.localRotation = Quaternion.Euler(0,0,0);
            // currentWorld.localScale = new Vector3(0.08f,0.08f,0.08f);
            // currentWorld.gameObject.layer = 29;
            Settnigs(currentWorld, world, new Vector3(0.074f,0.074f,0.074f));
            //targetLayer = 0;
        }    
    }

    public void Settnigs(Transform obj, Transform parent, Vector3 localScale)
    {
        obj.parent = parent;
        obj.position = parent.position;
        obj.localRotation = Quaternion.Euler(0,0,0);
        obj.localScale = localScale;
        obj.gameObject.layer = targetLayer;
    }
}
