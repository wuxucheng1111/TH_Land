using UnityEngine;
using System.Collections;

public class MoveMode_Random01 : MonoBehaviour, IMoveMode
{
    public int moveStartTime;          //开始移动的帧数
    public int moveTime;               //移动一次的帧数
    public int moveStopTime;           //移动后停止的帧数
    public float moveSpeed;            //移动速度

    int stepTimeCount;          //起算点
    Vector3 moveDirection;      //移动方向

    Animator moveAnimator;      //角色animator
    int horizontalHash;         //左右参数
    int verticalHash;           //上下参数
    int animationHash;          //动画状态名称

    // Use this for initialization
    void Start()
    {
        stepTimeCount = Time.frameCount;
        moveDirection = Random.insideUnitCircle.normalized;

        moveAnimator = GetComponent<Animator>();
        horizontalHash = Animator.StringToHash("AxisX");
        verticalHash = Animator.StringToHash("AxisY");
        animationHash = Animator.StringToHash("Enemy_Bat02_Move");
    }

    // Update is called once per frame
    void Update()
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
            if ((Time.frameCount - stepTimeCount - moveStartTime) % (moveTime + moveStopTime) == 0)
            {
                moveDirection = Random.insideUnitCircle.normalized;
            }
            if ((Time.frameCount - stepTimeCount - moveStartTime) % (moveTime + moveStopTime) < moveTime)
            {
                moveAnimator.SetFloat(horizontalHash, moveDirection.x);
                moveAnimator.SetFloat(verticalHash, moveDirection.y);
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
        }
    }

    public float directionAngle
    {
        get
        {
            return Mathf.Atan2(moveDirection.y, moveDirection.x)-Mathf.PI/2;
        }
    }
}
