using UnityEngine;
using System.Collections;

public abstract class EnemyModeManager : MonoBehaviour
{
    public IMoveMode enemyMoveMode;
    public IAttackMode enemyAttackMode;
    public IHitMode enemyHitMode;
    public float enemySize;
    public abstract void SetMoveMode(IMoveMode moveMode);
    public abstract void SetAttackMode(IAttackMode attackMode);
    public abstract void SetHitMode(IHitMode hitMode);
    public abstract void SetEnemySize(float size);
}
