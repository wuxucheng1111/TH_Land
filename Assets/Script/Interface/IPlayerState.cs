using UnityEngine;
using System.Collections;

public interface IPlayerState
{
    float GetPlayerSize();
    void Move();
    void Attack();
}
