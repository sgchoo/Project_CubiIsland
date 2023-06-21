using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        
        if(timer < 1.4f)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Debug.Log("좌표고정");
        transform.Translate(Vector3.forward * 0.01f);
    }
}
