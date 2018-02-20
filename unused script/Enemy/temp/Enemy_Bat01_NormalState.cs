using UnityEngine;
using System.Collections;

public class Enemy_Bat01_NormalState : MonoBehaviour, IEnemyState
{
    EnemyAI_Bat01 enemyAI;
    int stepTimeCount;          //起算点
    int moveStartTime;          //开始移动的帧数
    int moveTime;               //移动一次的帧数
    int moveStopTime;           //移动后停止的帧数
    float moveSpeed;            //移动速度
    Vector3 moveDirection;      //移动方向

    Animator moveAnimator;      //角色animator
    int horizontalHash;         //左右参数
    int verticalHash;           //上下参数
    int animationHash;          //动画状态名称

    Vector3 relativeLaunchPosition;  //发射相对位置
    int bullentNumber;               //一波发射数量
    float bullentRange;              //子弹覆盖范围
    int bullentWave;                 //一轮发射波数
    int waveInterval;                //每波间隔
    int chargeFront;                 //攻击前摇
    int chargeBack;                  //攻击后摇

    void Start()
    {
        //移动相关参数
        enemyAI = GetComponent<EnemyAI_Bat01>();
        moveStartTime = enemyAI.moveStartTime;
        moveTime = enemyAI.moveTime;
        moveStopTime = enemyAI.moveStopTime;
        moveSpeed = enemyAI.moveSpeed;
        stepTimeCount = Time.frameCount;
        moveDirection = Random.insideUnitCircle.normalized;

        moveAnimator = GetComponent<Animator>();
        horizontalHash = Animator.StringToHash("AxisX");
        verticalHash = Animator.StringToHash("AxisY");
        animationHash = Animator.StringToHash("Enemy_BatMove");

        //弹幕相关参数
    }

    public void Appear()
    {
        throw new System.NotImplementedException();
    }

    public void Move(GameObject target)
    {
        
    }
    public void Move()
    {
        if ((Time.frameCount - stepTimeCount) < moveStartTime)
        {
            moveAnimator.Play(animationHash, 0, 0);
        }
        else
        {
            if ((Time.frameCount - stepTimeCount) % (moveTime + moveStopTime) == 0)
            {
                moveDirection = Random.insideUnitCircle.normalized;
            }
            if ((Time.frameCount - stepTimeCount) % (moveTime + moveStopTime) < moveTime)
            {
                moveAnimator.SetFloat(horizontalHash, moveDirection.x);
                moveAnimator.SetFloat(verticalHash, moveDirection.y);
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
        }
    }

    public void Attack()
    {
        //throw new System.NotImplementedException();
    }

    public void GoDie()
    {
        throw new System.NotImplementedException();
    }
}
