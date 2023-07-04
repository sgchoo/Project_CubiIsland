using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubiDirection
{
    public int directionNum;
}

public class CubiMove : MonoBehaviour
{
    [SerializeField] private CubiDirection cubiDir = new CubiDirection();
    

    private void Start() 
    {
        RandomDirection();
    }

    void RandomDirection()
    {
        cubiDir.directionNum = UnityEngine.Random.Range(-1, 2);
    }
}
