using UnityEngine;
using System.Collections;

public class MoveMode_Player_MouseDirection : MonoBehaviour, IMoveMode
{
    /// <summary>
    /// 角色移动速度
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// 鼠标到角色连线与y轴的夹角
    /// </summary>
    float directionAngle;

    Camera mCam;			//主相机
    Animator moveAnimator;  //角色animator
    int horizontalHash;     //左右参数
    int verticalHash;       //上下参数
    int animationHash;      //动画状态名称
    float moveHorizontal;   //左右按键
    float moveVertical;     //上下按键
    Vector3 moveDirection;  //角色移动方向

    // Use this for initialization
    void Start()
    {
        mCam = Camera.main;
        moveAnimator = GetComponent<Animator>();
        horizontalHash = Animator.StringToHash("AxisX");
        verticalHash = Animator.StringToHash("AxisY");
        animationHash = Animator.StringToHash("PlayYuyuko_Move");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //判断角色方向
        float hRatio = mCam.orthographicSize / Screen.height;   //相机大小与屏幕像素比值的一半
        float mX = mCam.transform.position.x + (Input.mousePosition.x * 2 - Screen.width) * hRatio - this.transform.position.x;
        float mY = mCam.transform.position.y + (Input.mousePosition.y * 2 - Screen.height) * hRatio - this.transform.position.y;
        directionAngle = Mathf.Atan2(mY, mX) - Mathf.PI / 2;	//鼠标到角色连线与y轴的夹角
        moveAnimator.SetFloat(horizontalHash, mX);
        moveAnimator.SetFloat(verticalHash, mY);

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
        moveDirection = new Vector3(moveHorizontal, moveVertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    float IMoveMode.directionAngle
    {
        get
        {
            return directionAngle;
        }
    }
}
