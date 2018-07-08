using UnityEngine;
using System.Collections;

public abstract class AAttackMode : MonoBehaviour
{
    public abstract void Attack();
    public abstract void PowerUp(int power);
}
