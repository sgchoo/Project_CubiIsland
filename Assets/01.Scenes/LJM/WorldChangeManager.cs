using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChangeManager : MonoBehaviour
{
    void Start()
    {
        Transform player = Instantiate(GameData.Instance.currentWorld).transform;
        player.parent = this.transform;
        player.localPosition = new Vector3(0,0,0);
        player.localRotation = this.transform.localRotation;
        player.localScale = new Vector3(0.0044f,0.0044f,0.0044f);
    }
}
