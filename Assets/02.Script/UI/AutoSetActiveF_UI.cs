using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetActiveF_UI : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetMouseButtonDown(0)||timer >= 4f)
        {
            gameObject.SetActive(false);
        }
    }
}
