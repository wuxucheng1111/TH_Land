using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_BatBullent01 : MonoBehaviour
{
    public float velocity;              //弹幕速度
    public float acceleration;          //弹幕加速度
    public float rotationVelocity;      //自转速度
    public int life;                    //弹幕生存时间
    public int attackPoint;             //弹幕攻击力
    public float bullentSize;           //攻击判定半径
    public bool isTrack;                //是否追尾弹
    public int effect;                  //攻击效果

    Vector3 direction;                  //实际移动速度
    int startTime;                      //弹幕产生的时间点
    List<GameObject> player;            //玩家列表

    // Use this for initialization
    void Awake()
    {
        player = MySceneManager.Instance.player;
        startTime = MySceneManager.Instance.frameSinceLevelLoad;
        direction = new Vector3(-velocity * Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), velocity * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((MySceneManager.Instance.frameSinceLevelLoad - startTime) > life)
        {
            Destroy(gameObject);
        }
        CollisionDet();
        transform.Translate(direction * Time.deltaTime, Space.World);
    }

    void CollisionDet()
    {
        for (int i = 0; i < player.Count; i++)
        {
            if ((transform.position - player[i].transform.position).magnitude < (player[i].GetComponent<PlayerControl>().playerSize + bullentSize))
            {
                player[i].GetComponent<PlayerControl>().modeManager.playerHitMode.IsHit(attackPoint, effect);
                Destroy(gameObject);
            }
        }
    }
}
