using UnityEngine;
using System.Collections;

public class AttackMode_Yuyuko_01 : MonoBehaviour, IAttackMode
{
    public GameObject bullentType;          //发射的子弹预设体
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public int chargeFront;                 //攻击前摇
    public int chargeBack;                  //攻击后摇

    int chargeFrontCount;                   //前摇计数
    int chargeBackCount;                    //后摇计算点（下次可攻击的时间点）

    // Use this for initialization
    void Start()
    {
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFrontCount = 0;
        chargeBackCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (Input.GetButton("Fire1") && (Time.frameCount - chargeBackCount - (bullentWave - 1) * waveInterval) > chargeBack)    //按下攻击键且没有处于后摇中
        {
            chargeFrontCount += 1;
            if (chargeFrontCount > chargeFront)
            {
                for (int i = 0; i < bullentWave; i++)   //进行数波发射
                {
                    Invoke("Launch", i * waveInterval / 60f);
                }
                chargeBackCount = Time.frameCount;      //后摇开始点
                chargeFrontCount = 0;                   //前摇计数清零
            }
        }
    }
    //public void Launch()
    //{
    //    float directionAngle = playerMove.directionAngle * Mathf.Deg2Rad;
    //    Vector3 LaunchPosition = transform.position + new Vector3(relativeLaunchPosition.x * Mathf.Cos(directionAngle) - relativeLaunchPosition.y * Mathf.Sin(directionAngle), relativeLaunchPosition.x * Mathf.Sin(directionAngle) + relativeLaunchPosition.y * Mathf.Cos(directionAngle), 0); //计算旋转后的偏移位置
    //    for (int i = 0; i < bullentNumber; i++)
    //    {
    //        Instantiate(bullentType, LaunchPosition, Quaternion.Euler(0, 0, playerMove.directionAngle - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
    //    }
    //}
}
