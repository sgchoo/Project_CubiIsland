using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableManager : MonoBehaviour
{

    public Button[] buttons;

    [SerializeField]
    public static List<Button> uiObject;
    

    private void Start() 
    {
        uiObject = new List<Button>();
        foreach(Button btn in buttons)
        {
            uiObject.Add(btn);
        }
    }

    public static void OnInteractbale()
    {
        foreach(var btn in uiObject)
        {
            btn.interactable = false;
        }
    }

    public static void OffInteractable()
    {
        foreach(var btn in uiObject)
        {
            btn.interactable = true;
        }
    }
}
