using UnityEngine;
using System.Collections;

public class Player_Yuyuko_NormalState : PlayerState
{
    IMoveMode playerMoveMode;
    IAttackMode playerAttackMode;
    public float playerSize;

    // Use this for initialization
    void Start()
    {
        playerMoveMode = GetComponentInChildren<MoveMode_Player_MouseDirection>();
        playerAttackMode = GetComponentInChildren<AttackMode_Yuyuko_01>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Move()
    {
        playerMoveMode.Move();
    }


    public override void Attack()
    {
        playerAttackMode.Attack();
    }

    public override  float GetPlayerSize()
    {
        return playerSize;
    }
}
