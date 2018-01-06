using UnityEngine;
using System.Collections;

public class Player_Yuyuko_NormalState : MonoBehaviour,IPlayerState
{
    IMoveMode playerMoveMode;
    IAttackMode playerAttackMode;

    // Use this for initialization
    void Start()
    {
        playerMoveMode = GetComponent<MoveMode_Player_MouseDirection>();
        playerAttackMode = GetComponent<AttackMode_Yuyuko_01>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        playerMoveMode.Move();
    }


    public void Attack()
    {
        playerAttackMode.Attack();
    }
}
