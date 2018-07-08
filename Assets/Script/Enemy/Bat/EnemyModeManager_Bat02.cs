using UnityEngine;
using System.Collections;

public class EnemyModeManager_Bat02 : AEnemyModeManager
{
    // Use this for initialization
    void Awake()
    {
        enemyHitMode = GetComponentInChildren<HitMode_Bat02_01>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMoveMode.Move();
        enemyAttackMode.Attack();
        enemyHitMode.Hit();
    }


    public override void SetMoveMode(AMoveMode moveMode)
    {
        enemyMoveMode = moveMode;
    }

    public override void SetAttackMode(AAttackMode attackMode)
    {
        enemyAttackMode = attackMode;
    }

    public override void SetHitMode(AHitMode hitMode)
    {
        enemyHitMode = hitMode;
    }

    public override void SetEnemySize(float size)
    {
        enemySize = size;
    }
}
