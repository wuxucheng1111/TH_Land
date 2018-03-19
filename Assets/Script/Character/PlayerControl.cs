using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public PlayerState playerState;
    public float playerSize { get { return playerState.GetPlayerSize(); } }     //角色判定半径
    public int maxPlayHP;
    public int playerHP;
    public Image barHP;

    // Use this for initialization
    void Start()
    {
        playerHP = maxPlayHP;
    }

    // Update is called once per frame
    void Update()
    {
        playerState.Move();
        playerState.Attack();
        barHP.fillAmount = (float)playerHP / (float)maxPlayHP;
    }
}
