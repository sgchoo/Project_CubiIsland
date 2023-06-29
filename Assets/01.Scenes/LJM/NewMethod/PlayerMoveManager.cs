using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    public Transform[] xAxis;
    public Transform[] yAxis;
    public Transform[] zAxis;

    public struct Roller
    {
        public Transform[] axis;
        public int index;
        public int rotateIndex;
        public int lastIndex;
        public int rotateLastIndex;
        public int length;
        public Roller (Transform[] _axis, int _index, int _rotateIndex, int _lastIndex, int _rotateLastIndex, int _length)
        {
            this.axis = _axis;
            this.index = _index;
            this.rotateIndex = _rotateIndex;
            this.lastIndex = _lastIndex;
            this.rotateLastIndex = _rotateLastIndex;
            this.length = _length;
        }
    }

    private Roller xAxisRoller;
    private Roller yAxisRoller;
    private Roller zAxisRoller;
    
    private Vector2 coords;

    public Transform parent;

    public float rotateSpeed;

    private Direction direction;
    public Transform arCamera;

    // 플레이어의 회전 중 상태를 표현하는 변수
    bool isRolling = false;

    void Start()
    {
        xAxisRoller = new Roller(xAxis, 0, 1, 3, xAxis.Length-2, xAxis.Length-1);
        yAxisRoller = new Roller(yAxis, 0, 1, 3, xAxis.Length-2, yAxis.Length-1);
        zAxisRoller = new Roller(zAxis, 0, 1, 3, xAxis.Length-2, zAxis.Length-1);

        coords = new Vector2(2,1);
    }

    void Update()
    {
        if(isRolling)return;

        
        if      (Input.GetKeyDown(KeyCode.RightArrow))   StartCoroutine(Rolling(Vector3.right));
        else if (Input.GetKeyDown(KeyCode.LeftArrow))    StartCoroutine(Rolling(Vector3.left));
        else if (Input.GetKeyDown(KeyCode.UpArrow))      StartCoroutine(Rolling(Vector3.forward));
        else if (Input.GetKeyDown(KeyCode.DownArrow))    StartCoroutine(Rolling(Vector3.back));
    }

    // private void SetDirection()
    // {
    //     direction = arCamera.GetComponent<DrawRay>().RayForDirection(); 
    //     if(direction == Direction.none) return;
    //     // 만약 카메라가 바라보는 면과 플레이어가 서있는 면이 다르면 함수를 종료해라
    //     //if(DrawRay.hitAxis != CollideAxis.axis) return;

    //     switch(direction) 
    //     {
    //         case Direction.forward : StartCoroutine(Rolling(Vector3.forward)); break;
    //         case Direction.right : StartCoroutine(Rolling(Vector3.right)); break;
    //         case Direction.back : StartCoroutine(Rolling(Vector3.back)); break;
    //         case Direction.left : StartCoroutine(Rolling(Vector3.left)); break;
    //     }
    // }

    private IEnumerator Rolling(Vector3 dir)
    {
        isRolling = true;

        float angle = 90f;
        
        Transform rotateTarget = default(Transform);
        
        // 회전시킬 타겟 설정
        if(dir == Vector3.forward)
        {
            if      (zAxisRoller.index == 0) rotateTarget = xAxisRoller.axis[xAxisRoller.index];
            else if (zAxisRoller.index == 1) rotateTarget = yAxisRoller.axis[yAxisRoller.index];
            else if (zAxisRoller.index == 2) rotateTarget = xAxisRoller.axis[xAxisRoller.rotateIndex];
            else if (zAxisRoller.index == 3) rotateTarget = yAxisRoller.axis[yAxisRoller.rotateIndex];

            if(coords.y == 4) { angle += 90f; }
        }
        else if(dir == Vector3.back)
        {
            if      (zAxisRoller.index == 0) rotateTarget = xAxisRoller.axis[xAxisRoller.lastIndex];
            else if (zAxisRoller.index == 1) rotateTarget = yAxisRoller.axis[yAxisRoller.lastIndex];
            else if (zAxisRoller.index == 2) rotateTarget = xAxisRoller.axis[xAxisRoller.rotateLastIndex];
            else if (zAxisRoller.index == 3) rotateTarget = yAxisRoller.axis[yAxisRoller.rotateLastIndex];
            if(coords.y == 0) { angle += 90f; }
        }
        else if (dir == Vector3.right)
        {
            if (xAxisRoller.index == 0) rotateTarget = zAxisRoller.axis[zAxisRoller.index];
            if (xAxisRoller.index == 1) rotateTarget = yAxisRoller.axis[yAxisRoller.index];
            if (xAxisRoller.index == 2) rotateTarget = zAxisRoller.axis[zAxisRoller.rotateIndex];
            if (xAxisRoller.index == 3) rotateTarget = yAxisRoller.axis[yAxisRoller.rotateIndex];

            if(coords.x == 4) { angle += 90f; }
        }
        else if (dir == Vector3.left)
        {
            if (xAxisRoller.index == 0) rotateTarget = zAxisRoller.axis[zAxisRoller.lastIndex];
            if (xAxisRoller.index == 1) rotateTarget = yAxisRoller.axis[yAxisRoller.lastIndex];
            if (xAxisRoller.index == 2) rotateTarget = zAxisRoller.axis[zAxisRoller.rotateLastIndex];
            if (xAxisRoller.index == 3) rotateTarget = yAxisRoller.axis[yAxisRoller.rotateLastIndex];
            if(coords.x == 0) { angle += 90f; }
        }
        
        AxisPushToPlayer(rotateTarget);
        
        // 실제 회전
        while (angle > 0)
        {
            float rotateAngle = Time.deltaTime * rotateSpeed;
            if(rotateAngle >= angle) rotateAngle = angle;
            
            if(dir == Vector3.forward)
            {
                if (zAxisRoller.index == 0) rotateTarget.Rotate(Vector3.right, rotateAngle, Space.Self);
                else if (zAxisRoller.index == 1) rotateTarget.Rotate(Vector3.up, rotateAngle, Space.Self);
                else if (zAxisRoller.index == 2) rotateTarget.Rotate(Vector3.left, rotateAngle, Space.Self);
                else if (zAxisRoller.index == 3) rotateTarget.Rotate(Vector3.down, rotateAngle, Space.Self);
                
            }
            else if (dir == Vector3.back)
            {
                if (zAxisRoller.index == 0) rotateTarget.Rotate(Vector3.left, rotateAngle, Space.Self);
                else if (zAxisRoller.index == 1)  rotateTarget.Rotate(Vector3.down, rotateAngle, Space.Self);
                else if (zAxisRoller.index == 2)  rotateTarget.Rotate(Vector3.right, rotateAngle, Space.Self);
                else if (zAxisRoller.index == 3)  rotateTarget.Rotate(Vector3.up, rotateAngle, Space.Self);
            }
            else if (dir == Vector3.right)
            {
                if (xAxisRoller.index == 0) rotateTarget.Rotate(Vector3.back, rotateAngle, Space.Self);
                if (xAxisRoller.index == 1) rotateTarget.Rotate(Vector3.down, rotateAngle, Space.Self);
                if (xAxisRoller.index == 2) rotateTarget.Rotate(Vector3.forward, rotateAngle, Space.Self);
                if (xAxisRoller.index == 3) rotateTarget.Rotate(Vector3.up, rotateAngle, Space.Self);
            }
            else if (dir == Vector3.left)
            {
                if (xAxisRoller.index == 0) rotateTarget.Rotate(Vector3.forward, rotateAngle, Space.Self);
                if (xAxisRoller.index == 1) rotateTarget.Rotate(Vector3.up, rotateAngle, Space.Self);
                if (xAxisRoller.index == 2) rotateTarget.Rotate(Vector3.back, rotateAngle, Space.Self);
                if (xAxisRoller.index == 3) rotateTarget.Rotate(Vector3.down, rotateAngle, Space.Self);
            }
            
            angle -= rotateAngle;
            yield return null;
        }

        AxisPopToPlayer();        
        
        // 후처리
        PostProcess(dir);
        
        isRolling = false;
        yield return null;
    }

    private void PostProcess(Vector3 dir)
    {
        SetIndex(dir);
        CalculateCoords();
    }

    private void AxisPushToPlayer(Transform checkTarget)
    {
        foreach(var xTarget in xAxisRoller.axis)
        {
            if(xTarget == checkTarget) continue;
            xTarget.parent = this.transform;
        }
        
        foreach(var yTarget in yAxisRoller.axis)
        {
            if(yTarget == checkTarget) continue;
            yTarget.parent = this.transform;
        }
        
        foreach(var zTarget in zAxisRoller.axis)
        {
            if(zTarget == checkTarget) continue;
            zTarget.parent = this.transform;
        }

        this.transform.parent = checkTarget;
    }

    private void AxisPopToPlayer()
    {
        foreach(var xTarget in xAxisRoller.axis)
        {
            xTarget.parent = parent;
        }
        
        foreach(var yTarget in yAxisRoller.axis)
        {
            yTarget.parent = parent;
        }
        
        foreach(var zTarget in zAxisRoller.axis)
        {
            zTarget.parent = parent;
        }

        this.transform.parent = parent;
    }

    private void SetIndex(Vector3 dir)
    {
        if (dir == Vector3.forward)
        {
            if (zAxisRoller.index == 0) UpIndexSet(ref xAxisRoller);
            else if (zAxisRoller.index == 1) UpIndexSet(ref yAxisRoller);
            else if (zAxisRoller.index == 2) DownIndexSet(ref xAxisRoller);
            else if (zAxisRoller.index == 3) DownIndexSet(ref yAxisRoller);
            coords.y += 1;
        }
        else if (dir == Vector3.back)
        {
            if (zAxisRoller.index == 0) DownIndexSet(ref xAxisRoller);
            else if (zAxisRoller.index == 1) DownIndexSet(ref yAxisRoller);
            else if (zAxisRoller.index == 2) UpIndexSet(ref xAxisRoller);
            else if (zAxisRoller.index == 3) UpIndexSet(ref yAxisRoller);
            coords.y -= 1;
        }
        else if (dir == Vector3.right)
        {
            if (xAxisRoller.index == 0) UpIndexSet(ref zAxisRoller);
            else if (xAxisRoller.index == 1) UpIndexSet(ref yAxisRoller);
            else if (xAxisRoller.index == 2) DownIndexSet(ref zAxisRoller);
            else if (xAxisRoller.index == 3) DownIndexSet(ref yAxisRoller);
            coords.x += 1;
        }
        else if (dir == Vector3.left)
        {
            if (xAxisRoller.index == 0) DownIndexSet(ref zAxisRoller);
            else if (xAxisRoller.index == 1) DownIndexSet(ref yAxisRoller);
            else if (xAxisRoller.index == 2) UpIndexSet(ref zAxisRoller);
            else if (xAxisRoller.index == 3) UpIndexSet(ref yAxisRoller);
            coords.x -= 1;
        }
    }

    private void UpIndexSet(ref Roller roller)
    {
        roller.index += 1;
        roller.lastIndex = roller.index - 1;

        if( roller.index > roller.length) ResetRoller(ref roller);
        
        roller.rotateIndex += 1;
        if (roller.rotateIndex > roller.length) roller.rotateIndex = 0;

        roller.rotateLastIndex +=1;
        if (roller.rotateLastIndex  > roller.length) roller.rotateLastIndex = 0;
        //SetRollerLastProperty(ref roller);
    }

    private void DownIndexSet(ref Roller roller)
    {
        roller.lastIndex -= 1;
        roller.index = roller.lastIndex + 1;
        
        if( roller.lastIndex < 0) ResetRoller(ref roller);
        //SetRollerLastProperty(ref roller);

        roller.rotateIndex -= 1;
        if (roller.rotateIndex < 0) roller.rotateIndex = roller.length;

        roller.rotateLastIndex -=1;
        if (roller.rotateLastIndex < 0) roller.rotateLastIndex = roller.length;
    }
    
    private void ResetRoller(ref Roller roller)
    {
        roller.index = 0;
        roller.lastIndex = roller.length;
    }

    private void SetRollerLastProperty(ref Roller roller)
    {
        roller.rotateIndex -= 1;
        if(roller.rotateIndex > roller.length) roller.rotateIndex = 0;

        roller.rotateLastIndex -= 1;
        if(roller.rotateLastIndex < 0) roller.rotateLastIndex = roller.length;
    }

    

    private void CalculateCoords()
    {
        if      (coords.y > 4) coords.y = 0;
        else if (coords.y < 0) coords.y = 4;
        else if (coords.x > 4) coords.x = 0;
        else if (coords.x < 0) coords.x = 4;
    }


}
