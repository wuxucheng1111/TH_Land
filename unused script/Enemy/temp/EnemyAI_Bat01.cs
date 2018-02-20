using UnityEngine;
using System.Collections;

public class EnemyAI_Bat01 : MonoBehaviour
{
    public GameObject sceneManager;         //Manager
    //移动相关参数
    public int moveStartTime;       //开始移动的帧数
    public int moveTime;        //移动一次的帧数
    public int moveStopTime;        //移动后停止的帧数
    public float moveSpeed;     //移动速度
    public GameObject target;   //移动目标
    //弹幕相关参数
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public int chargeFront;                 //攻击前摇
    public int chargeBack;                  //攻击后摇

    IEnemyState BatState;

    // Use this for initialization
    void Start()
    {
        target = sceneManager.GetComponent<SceneManager>().player;
        BatState = GetComponent<Enemy_Bat01_NormalState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            BatState.Move();
        }
        else
        {
            BatState.Move(target);
        }
        BatState.Attack();
    }
}
