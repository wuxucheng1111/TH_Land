using UnityEngine;
using System.Collections;

public class PlayerModeManager_Yuyuko : APlayerModeManager
{
    // Update is called once per frame
    void Update()
    {
        playerMoveMode.Move();
        playerAttackMode.Attack();
        playerHitMode.Hit();
    }

    public override void SetMoveMode(AMoveMode moveMode)
    {
        playerMoveMode = moveMode;
    }

    public override void SetAttackMode(AAttackMode attackMode)
    {
        playerAttackMode = attackMode;
    }

    public override void SetPlayerSize(float size)
    {
        playerSize = size;
    }

    public override void SetHitMode(AHitMode hitMode)
    {
        playerHitMode = hitMode;
    }
}
