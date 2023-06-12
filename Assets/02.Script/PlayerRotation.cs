using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] int rollSpeed = 3;

    public Transform tr;
    private AudioSource audioSource;
    public AudioClip rollSound;
    public AudioClip landingSound;

    bool isMove = false;

    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(isMove)return;

        Assemble(Vector3.forward);

        void Assemble(Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Rolling(anchor, axis));
        }
    }
    private IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        
        isMove = true;

        // yield return new WaitForSeconds(0.2f);
        // audioSource.clip = rollSound;
        // audioSource.Play();

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        audioSource.Stop();
        audioSource.clip = landingSound;
        audioSource.Play();
        isMove = false;
    }
}
