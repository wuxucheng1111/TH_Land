using UnityEngine;
using System.Collections;

public class AttackMode_Yuyuko_02 : AAttackMode
{
    public GameObject bullentType;          //发射的子弹预设体
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public int chargeFront;                 //攻击前摇
    public int chargeBack;                  //攻击后摇
    public int life;                        //弹幕生存时间
    //[HideInInspector]
    Vector3 LaunchPosition;
    public MoveMode_Player_DirectionFixed moveModeFixed;

    int chargeFrontCount;                   //前摇计数
    int chargeFinishFrame;                  //蓄力完成帧（下次可攻击的时间点）
    PlayerModeManager_Yuyuko playerMode;
    AMoveMode playerMove;
    public Transform playerTransform;

    public AudioSource attackSEsource;
    public AudioClip attackSE;

    // Use this for initialization
    void Awake()
    {
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFrontCount = 0;
        chargeFinishFrame = 0;
        playerMode = playerTransform.GetComponent<PlayerModeManager_Yuyuko>();
        playerMove = playerMode.playerMoveMode;
        attackSEsource.clip = attackSE;
    }

    public override void Attack()
    {
        if (playerTransform.GetComponent<PlayerControl>().isDead)
            return;
        if (Input.GetButton("Fire1") && (MySceneManager.Instance.frameSinceLevelLoad > chargeFinishFrame))    //按下攻击键且没有处于后摇中
        {
            chargeFrontCount += 1;
            if (chargeFrontCount > chargeFront)
            {
                attackSEsource.Play();
                for (int i = 0; i < bullentWave; i++)   //进行数波发射
                {
                    Invoke("Launch", i * waveInterval / 60f);
                }
                chargeFinishFrame = MySceneManager.Instance.frameSinceLevelLoad + chargeBack + (bullentWave - 1) * waveInterval;      //下次可攻击的时间点
                chargeFrontCount = 0;                   //前摇计数清零
            }
        }
        else
        {
            chargeFrontCount = 0;
        }
    }

    public override void PowerUp(int power)
    {
        if ((bullentNumber + power) > 5)
        {
            bullentNumber = 5;
        }
        else
        {
            bullentNumber += power;
        }
    }

    public void Launch()
    {
        float directionAngle = playerMove.directionAngle;
        int depth = 0;
        if (directionAngle < 1.107f && directionAngle > -1.107f)
        {
            depth = 1;
        }
        else
        {
            depth = -1;
        }
        LaunchPosition = transform.position + new Vector3(relativeLaunchPosition.x * Mathf.Cos(directionAngle) - relativeLaunchPosition.y * Mathf.Sin(directionAngle), relativeLaunchPosition.x * Mathf.Sin(directionAngle) + relativeLaunchPosition.y * Mathf.Cos(directionAngle), depth); //计算旋转后的偏移位置
        if (bullentNumber == 1)
        {
            GameObject bullentIns = (GameObject)Instantiate(bullentType, LaunchPosition, Quaternion.Euler(0, 0, directionAngle * Mathf.Rad2Deg));
            bullentIns.transform.parent = MySceneManager.Instance.playerBullentsObj.transform;
        }
        else
        {
            for (int i = 0; i < bullentNumber; i++)
            {
                GameObject bullentIns = (GameObject)Instantiate(bullentType, LaunchPosition, Quaternion.Euler(0, 0, directionAngle * Mathf.Rad2Deg - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
                bullentIns.transform.parent = transform;
            }
        }
        playerTransform.GetComponent<PlayerModeManager_Yuyuko>().SetMoveMode(moveModeFixed);
        moveModeFixed.fixedFrame = life;
    }
}
