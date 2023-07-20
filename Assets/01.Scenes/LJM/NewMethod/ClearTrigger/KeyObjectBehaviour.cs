using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObjectBehaviour : MonoBehaviour
{
    public GameObject ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 10f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindKeyGameManager.GetKey();
            Instantiate(ps, this.transform.position + new Vector3(0, 0.01f, 0), Quaternion.Euler(-90, 0, 0));
            Handheld.Vibrate();
            Destroy(this.gameObject);
        }
    }
}
