using UnityEngine;
using System.Collections;

public class Enemy_Bat_NormalState : EnemyState
{
    public IMoveMode bat02moveMode;
    public IAttackMode bat02attackMode;
    public float enemySize;

    // Use this for initialization
    void Start()
    {
        bat02moveMode = GetComponentInChildren<MoveMode_Bat_Random01>();
        bat02attackMode = GetComponentInChildren<AttackMode_Bat_AimToPlayer01>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Appear()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        bat02moveMode.Move();
    }

    public override void Attack()
    {
        bat02attackMode.Attack();
    }

    public override void GoDie()
    {
        throw new System.NotImplementedException();
    }

    public override float GetEnemySize()
    {
        return enemySize;
    }
}
