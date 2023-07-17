using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerBehaviour : MonoBehaviour
{
    public GameObject ps;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Key")
        {
            TutorialGameManager.getKeyCount++;
            Instantiate(ps, other.transform.position + new Vector3(0, 0.01f, 0), Quaternion.Euler(-90, 0, 0));
            Destroy(other.gameObject);
        }

        if(other.transform.name == "EndZone")
        {
            TutorialGameManager.isFinish = true;
        }
    }
}
