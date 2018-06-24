using UnityEngine;
using System.Collections;

public class PlayerModeManager_Yuyuko : PlayerModeManager
{    
    // Use this for initialization
    void Awake()
    {
        playerMoveMode = GetComponentInChildren<MoveMode_Player_MouseDirection>();
        playerAttackMode = GetComponentInChildren<AttackMode_Yuyuko_02>();
        playerHitMode = GetComponentInChildren<HitMod_Yuyuko_01>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveMode.Move();
        playerAttackMode.Attack();
        playerHitMode.Hit();
    }

    public override void SetMoveMode(IMoveMode moveMode)
    {
        playerMoveMode = moveMode;
    }

    public override void SetAttackMode(IAttackMode attackMode)
    {
        playerAttackMode = attackMode;
    }

    public override void SetPlayerSize(float size)
    {
        playerSize = size;
    }

    public override void SetHitMode(IHitMode hitMode)
    {
        playerHitMode = hitMode;
    }
}
