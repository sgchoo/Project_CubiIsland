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
        if (GameData.Instance.CheckAssets())
        {
            isSet = true;
            Transform currentCharacter = Instantiate(GameData.Instance.currentCharacter).transform;
            Settnigs(currentCharacter, character, new Vector3(0.33f,0.33f,0.33f));

            Transform currentWorld = Instantiate(GameData.Instance.currentWorld).transform;
            Settnigs(currentWorld, world, new Vector3(0.074f,0.074f,0.074f));
            targetLayer = 0;
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
