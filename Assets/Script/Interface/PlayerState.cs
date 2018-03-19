using UnityEngine;
using System.Collections;

public abstract class PlayerState : MonoBehaviour
{
    public abstract float GetPlayerSize();
    public abstract void Move();
    public abstract void Attack();
}
