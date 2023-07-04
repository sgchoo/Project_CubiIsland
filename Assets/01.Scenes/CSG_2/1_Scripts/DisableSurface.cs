using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSurface : MonoBehaviour
{
    bool isInside;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 30 && !isInside)
        {
            other.transform.root.GetChild(0).gameObject.SetActive(false);
            Debug.Log(other.transform.name);
            StartCoroutine(ChangeFalseValue());
        }

        if(other.gameObject.layer == 30 && isInside)
        {
            other.transform.root.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(ChangeTrueValue());
        }
    }

    IEnumerator ChangeFalseValue()
    {
        yield return new WaitForSeconds(0.5f);

        isInside = true;
    }

    IEnumerator ChangeTrueValue()
    {
        yield return new WaitForSeconds(0.5f);

        isInside = false;
    }
}
