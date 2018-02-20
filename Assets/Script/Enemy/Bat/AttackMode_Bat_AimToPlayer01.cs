using UnityEngine;
using System.Collections;

public class AttackMode_Bat_AimToPlayer01 : MonoBehaviour, IAttackMode
{
    public GameObject bullentType;          //弹幕预制体
    public GameObject player;               //目标玩家
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public int attackStartTime;             //攻击开始时间
    public int chargeBack;                  //攻击后摇

    int chargeFinishFrame;                    //蓄力完成帧（下次可攻击的时间点）

    // Use this for initialization
    void Start()
    {
        player = SceneManager.Instance.player;
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFinishFrame = attackStartTime;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (Time.frameCount > chargeFinishFrame)
        {
            for (int i = 0; i < bullentWave; i++)   //进行数波发射
            {
                Invoke("Launch", i * waveInterval / 60f);
            }
            chargeFinishFrame = Time.frameCount + (bullentWave - 1) * waveInterval + chargeBack;
        }
    }

    void Launch()
    {
        float directionAngle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) - Mathf.PI / 2;  //与玩家的连线与Y轴的夹角
        Vector3 launchPosition = transform.position + new Vector3(relativeLaunchPosition.x * Mathf.Cos(directionAngle) - relativeLaunchPosition.y * Mathf.Sin(directionAngle), relativeLaunchPosition.x * Mathf.Sin(directionAngle) + relativeLaunchPosition.y * Mathf.Cos(directionAngle), 0); //计算旋转后的偏移位置
        for (int i = 0; i < bullentNumber; i++)
        {
            Instantiate(bullentType, launchPosition, Quaternion.Euler(0, 0, directionAngle*Mathf.Rad2Deg - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
        }
    }
}
