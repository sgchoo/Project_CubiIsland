using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgScrolling_UI : MonoBehaviour
{

    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(x,y) * Time.deltaTime, rawImage.uvRect.size);
    }
}
