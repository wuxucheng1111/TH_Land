using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackMode_Bat02_AimToPlayer01 : AAttackMode
{
    public GameObject bullentType;          //弹幕预制体
    public List<GameObject> player;         //玩家列表
    public GameObject aimedPlayer;          //目标玩家
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public int attackStartTime;             //攻击开始时间
    public int chargeBack;                  //攻击后摇
    public int attackPoint;                 //近战攻击力
    public float batSize;                   //近战攻击范围
    public int effect;                      //近战攻击效果

    int chargeFinishFrame;                  //蓄力完成帧（下次可攻击的时间点）

    public AudioSource attackSESource;
    public AudioClip attackSE;

    // Use this for initialization
    void Awake()
    {
        player = MySceneManager.Instance.player;
        if (player.Count != 0)
        {
            aimedPlayer = player[0];
        }
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFinishFrame = MySceneManager.Instance.frameSinceLevelLoad + attackStartTime;
        attackSESource.clip = attackSE;
    }

    public override void Attack()
    {
        if (MySceneManager.Instance.frameSinceLevelLoad > chargeFinishFrame)
        {
            for (int i = 0; i < bullentWave; i++)   //进行数波发射
            {
                Invoke("Launch", i * waveInterval / 60f);
            }
            chargeFinishFrame = MySceneManager.Instance.frameSinceLevelLoad + (bullentWave - 1) * waveInterval + chargeBack;
        }
        CollisionDet();
    }

    public override void PowerUp(int power)
    {
        throw new System.NotImplementedException();
    }

    void Launch()
    {
        if (aimedPlayer == null)
            return;
        float directionAngle = Mathf.Atan2(aimedPlayer.transform.position.y - transform.position.y, aimedPlayer.transform.position.x - transform.position.x) - Mathf.PI / 2;  //与玩家的连线与Y轴的夹角
        Vector3 launchPosition = transform.position + new Vector3(relativeLaunchPosition.x * Mathf.Cos(directionAngle) - relativeLaunchPosition.y * Mathf.Sin(directionAngle), relativeLaunchPosition.x * Mathf.Sin(directionAngle) + relativeLaunchPosition.y * Mathf.Cos(directionAngle), 0); //计算旋转后的偏移位置
        if (bullentNumber == 1)
        {
            GameObject bullentIns = (GameObject)Instantiate(bullentType, launchPosition, Quaternion.Euler(0, 0, directionAngle * Mathf.Rad2Deg));
            bullentIns.transform.parent = MySceneManager.Instance.enemyBullentsObj.transform;
        }
        else
        {
            for (int i = 0; i < bullentNumber; i++)
            {
                GameObject bullentIns = (GameObject)Instantiate(bullentType, launchPosition, Quaternion.Euler(0, 0, directionAngle * Mathf.Rad2Deg - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
                bullentIns.transform.parent = MySceneManager.Instance.enemyBullentsObj.transform;
            }
        }
        attackSESource.Play();
    }

    void CollisionDet()
    {
        for (int i = 0; i < player.Count; i++)
        {
            if ((transform.position - player[i].transform.position).magnitude < (player[i].GetComponent<PlayerControl>().playerSize + batSize))
            {
                player[i].GetComponent<PlayerControl>().modeManager.playerHitMode.IsHit(attackPoint, effect);
            }
        }
    }
}
