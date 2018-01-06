using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
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
