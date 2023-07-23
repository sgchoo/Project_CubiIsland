using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBaseMap : MonoBehaviour
{
    public Texture2D[] textures;
    public GameObject[] weather;
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
                weather[0].SetActive(true);
                weather[1].SetActive(false);
                break;

            case "Map02_Snow":
                myRender.material.mainTexture = textures[1];
                weather[0].SetActive(false);
                weather[1].SetActive(true);
                break;

            case "Map03_Desert":
                myRender.material.mainTexture = textures[2];
                weather[0].SetActive(false);
                weather[1].SetActive(false);
                break;
        }
    }
}
