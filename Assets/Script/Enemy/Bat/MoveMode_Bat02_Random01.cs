﻿using UnityEngine;
using System.Collections;

public class MoveMode_Bat02_Random01 : AMoveMode
{
    public int moveStartTime;          //开始移动的帧数
    public int moveTime;               //移动一次的帧数
    public int moveStopTime;           //移动后停止的帧数

    int startTimeCount;         //起算点
    Vector3 moveDirection;      //移动方向

    Animator moveAnimator;      //角色animator
    int horizontalHash;         //左右参数
    int verticalHash;           //上下参数
    public Transform enemyTransform;

    // Use this for initialization
    void Awake()
    {
        startTimeCount = MySceneManager.Instance.frameSinceLevelLoad;
        moveDirection = Random.insideUnitCircle.normalized;
        moveAnimator = enemyTransform.GetComponent<Animator>();
        horizontalHash = Animator.StringToHash("AxisX");
        verticalHash = Animator.StringToHash("AxisY");
    }

    public override void Move()
    {
        if ((MySceneManager.Instance.frameSinceLevelLoad - startTimeCount) > moveStartTime)
        {
            if ((MySceneManager.Instance.frameSinceLevelLoad - startTimeCount - moveStartTime) % (moveTime + moveStopTime) == 0)
            {
                moveDirection = Random.insideUnitCircle.normalized;
            }
            if ((MySceneManager.Instance.frameSinceLevelLoad - startTimeCount - moveStartTime) % (moveTime + moveStopTime) < moveTime)
            {
                moveAnimator.SetFloat(horizontalHash, moveDirection.x);
                moveAnimator.SetFloat(verticalHash, moveDirection.y);
                enemyTransform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
        }
        directionAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) - Mathf.PI / 2;
    }

    public override void IsDelayed()
    {
        throw new System.NotImplementedException();
    }
}
