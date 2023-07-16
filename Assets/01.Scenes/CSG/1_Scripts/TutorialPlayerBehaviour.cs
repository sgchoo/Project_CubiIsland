using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Key")
        {
            TutorialGameManager.getKeyCount++;
            Destroy(other.gameObject);
        }

        if(other.transform.name == "EndZone")
        {
            TutorialGameManager.isFinish = true;
        }
    }
}
