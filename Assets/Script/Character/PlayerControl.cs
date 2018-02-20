using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    public List<IPlayerState> stateList;
    IPlayerState playerState;
    // Use this for initialization
    void Start()
    {
        playerState = GetComponent<Player_Yuyuko_NormalState>();
    }

    // Update is called once per frame
    void Update()
    {
        playerState.Move();
        playerState.Attack();
    }
}
