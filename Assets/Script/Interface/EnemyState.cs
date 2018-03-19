using UnityEngine;
using System.Collections;

public abstract class EnemyState : MonoBehaviour
{
    public abstract float GetEnemySize();
    public abstract void Appear();
    public abstract void Move();
    public abstract void Attack();
    public abstract void GoDie();
}
