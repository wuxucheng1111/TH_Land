﻿using UnityEngine;
using System.Collections;

public class Enemy_Bat02_NormalState : MonoBehaviour, IEnemyState
{
    public IMoveMode bat02moveMode;
    public IAttackMode bat02attackMode;
    // Use this for initialization
    void Start()
    {
        bat02moveMode = GetComponent<MoveMode_Random01>();
        bat02attackMode = GetComponent<AttackMode_AimToPlayer01>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Appear()
    {
        throw new System.NotImplementedException();
    }

    public void Move(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        bat02moveMode.Move();
    }

    public void Attack()
    {
        bat02attackMode.Attack();
    }

    public void GoDie()
    {
        throw new System.NotImplementedException();
    }
}
