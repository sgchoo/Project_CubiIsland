using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("A : " + GameData.Instance.currentCharacter.name);
        Transform player = Instantiate(GameData.Instance.currentCharacter).transform;
        player.parent = this.transform;
        player.localPosition = new Vector3(0,-0.5f,0);
        player.localRotation = this.transform.localRotation;
        player.localScale = new Vector3(0.5f,0.5f,0.5f);
    }

}
