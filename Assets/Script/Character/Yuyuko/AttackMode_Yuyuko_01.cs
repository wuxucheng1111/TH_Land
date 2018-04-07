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
    int chargeFinishFrame;                  //蓄力完成帧（下次可攻击的时间点）
    IMoveMode playerMove;

    public AudioSource attackSEsource;
    public AudioClip attackSE;

    // Use this for initialization
    void Start()
    {
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFrontCount = 0;
        chargeFinishFrame = 0;
        playerMove = transform.parent.GetComponentInChildren<MoveMode_Player_MouseDirection>();
        attackSEsource = GetComponent<AudioSource>();
        attackSEsource.clip = attackSE;
    }

    public void Attack()
    {
        if (transform.parent.GetComponent<PlayerControl>().isDead)
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
    public void Launch()
    {
        float directionAngle = playerMove.directionAngle;
        Vector3 LaunchPosition = transform.position + new Vector3(relativeLaunchPosition.x * Mathf.Cos(directionAngle) - relativeLaunchPosition.y * Mathf.Sin(directionAngle), relativeLaunchPosition.x * Mathf.Sin(directionAngle) + relativeLaunchPosition.y * Mathf.Cos(directionAngle), 0); //计算旋转后的偏移位置
        for (int i = 0; i < bullentNumber; i++)
        {
            GameObject bullentIns = (GameObject)Instantiate(bullentType, LaunchPosition, Quaternion.Euler(0, 0, playerMove.directionAngle * Mathf.Rad2Deg - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
            bullentIns.transform.parent = MySceneManager.Instance.playerBullentsObj.transform;
        }
    }
}
