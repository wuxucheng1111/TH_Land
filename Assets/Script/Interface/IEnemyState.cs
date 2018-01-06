using UnityEngine;
using System.Collections;

public interface IEnemyState
{
    void Appear();
    void Move(GameObject target);
    void Move();
    void Attack();
    void GoDie();
}
