using UnityEngine;
using System.Collections;

public class PlayerMove_KeyDirection : MonoBehaviour
{
    /// <summary>
    /// 角色移动速度
    /// </summary>
    public float moveSpeed;

    Animator moveAnimator;  //角色animator
    float moveHorizontal;   //左右按键
    float moveVertical;     //上下按键
    int horizontalHash = Animator.StringToHash("AxisX");
    int verticalHash = Animator.StringToHash("AxisY");
    int animationHash = Animator.StringToHash("PlayYuyuko_Move");
    Vector2 moveDirection;  //角色移动方向

    // Use this for initialization
    void Start()
    {
        moveAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //判断角色方向
        if (moveHorizontal != 0 || moveVertical != 0)   //animator参数设置
        {
            moveAnimator.SetFloat(horizontalHash, moveHorizontal);
            moveAnimator.SetFloat(verticalHash, moveVertical);
        }

        //动画播放
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            moveAnimator.Play(animationHash, 0, 0);
            moveAnimator.speed = 0;
        }
        else
        {
            moveAnimator.speed = 1;
        }

        //角色移动
        moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;
        transform.Translate(moveDirection * moveSpeed);
    }
}
