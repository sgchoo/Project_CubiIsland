using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 0.5f;
    }
}
