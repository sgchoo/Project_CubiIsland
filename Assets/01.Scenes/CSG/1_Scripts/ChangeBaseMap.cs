using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBaseMap : MonoBehaviour
{
    public Texture2D[] textures;
    private Renderer myRender;

    private Material curMat;

    private void Start() 
    {
        myRender = this.GetComponent<Renderer>();
    }

    private void Update() 
    {
        ChangeMainTexture();
    }

    private void ChangeMainTexture()
    {
        switch(GameData.Instance.currentWorld.name)
        {
            case "Map01_Forest":
                myRender.material.mainTexture = textures[0];
                break;

            case "Map02_Snow":
                myRender.material.mainTexture = textures[1];
                break;

            case "Map03_Desert":
                myRender.material.mainTexture = textures[2];
                break;
        }
    }
}
