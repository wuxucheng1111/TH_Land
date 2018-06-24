using UnityEngine;
using System.Collections;

public class EnemyModeManager_Bat02 : EnemyModeManager
{
    // Use this for initialization
    void Awake()
    {
        enemyMoveMode = GetComponentInChildren<MoveMode_Bat02_Random01>();
        enemyAttackMode = GetComponentInChildren<AttackMode_Bat02_AimToPlayer01>();
        enemyHitMode = GetComponentInChildren<HitMode_Bat02_01>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMoveMode.Move();
        enemyAttackMode.Attack();
        enemyHitMode.Hit();
    }


    public override void SetMoveMode(IMoveMode moveMode)
    {
        enemyMoveMode = moveMode;
    }

    public override void SetAttackMode(IAttackMode attackMode)
    {
        enemyAttackMode = attackMode;
    }

    public override void SetHitMode(IHitMode hitMode)
    {
        enemyHitMode = hitMode;
    }

    public override void SetEnemySize(float size)
    {
        enemySize = size;
    }
}
