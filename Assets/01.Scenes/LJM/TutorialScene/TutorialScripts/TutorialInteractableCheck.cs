using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInteractableCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameData.Instance.tutorialPlaza)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
        if (this.gameObject.name == "ButtonStart" && TutorialScriptController.tutorialCount == 2)
        {
            this.GetComponent<Button>().interactable = true;
        }
    }

}
