using UnityEngine;
using System.Collections;

public abstract class PlayerModeManager : MonoBehaviour
{
    public IMoveMode playerMoveMode;
    public IAttackMode playerAttackMode;
    public IHitMode playerHitMode;
    public float playerSize;
    public abstract void SetMoveMode(IMoveMode moveMode);
    public abstract void SetAttackMode(IAttackMode attackMode);
    public abstract void SetHitMode(IHitMode hitMode);
    public abstract void SetPlayerSize(float size);
}
