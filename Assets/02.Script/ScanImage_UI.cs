using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanImage_UI : MonoBehaviour
{
    public static bool ScanimageAct;
    private Image ScanImage;
    private Animator  Act;

    // Start is called before the first frame update
    void Start()
    {
        ScanimageAct = false;
        //gameObject.SetActive(false);
        // 이미지를 먼저 꺼보고, 안되면 애니메이션도 끄기
        ScanImage = GetComponent<Image>();
        ScanImage.enabled = false;
        Act = GetComponent<Animator>();
        Act.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScanimageAct == true)
        {
            print("이미지켜져라 얍");
            ScanImage.enabled = true;
            Act.enabled = true;
        }
    }
}
