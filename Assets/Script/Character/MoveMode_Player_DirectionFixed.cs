using UnityEngine;
using System.Collections;

public class MoveMode_Player_DirectionFixed : AMoveMode
{
    public Transform playerTransform;  //父物体(含有animator)
    APlayerModeManager modeManager;
    Camera mCam;			    //主相机
    float hRatio;               //相机大小与屏幕像素比值的一半

    Animator moveAnimator;      //角色animator
    //int horizontalHash;         //左右参数
    //int verticalHash;           //上下参数
    float moveHorizontal;       //左右按键
    float moveVertical;         //上下按键
    Vector3 moveDirection;      //角色移动方向
    float moveBorderX;
    float moveBorderY;

    public int fixedFrame;
    private int modeStartFrame;

    public AMoveMode moveModeNormal;
    public AMoveMode moveModeDelay;

    // Use this for initialization
    void Awake()
    {
        playerTransform = transform.parent.parent;
        modeManager = playerTransform.GetComponent<PlayerControl>().modeManager;
        mCam = Camera.main;
        moveAnimator = playerTransform.GetComponent<Animator>();
        //horizontalHash = Animator.StringToHash("AxisX");
        //verticalHash = Animator.StringToHash("AxisY");
        moveBorderX = MySceneManager.Instance.GetAreaBorderX() - playerTransform.GetComponent<PlayerControl>().playerSize * 2;
        moveBorderY = MySceneManager.Instance.GetAreaBorderY() - playerTransform.GetComponent<PlayerControl>().playerSize * 2;
        modeStartFrame = 0;
    }

    public override void Move()
    {
        if (playerTransform.GetComponent<PlayerControl>().isDead)
        {
            moveAnimator.speed = 1;
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            //判断角色方向
            float hRatio = mCam.orthographicSize / Screen.height;   //相机大小与屏幕像素比值的一半
            float mX = mCam.transform.position.x + (Input.mousePosition.x * 2 - Screen.width) * hRatio - this.transform.position.x;
            float mY = mCam.transform.position.y + (Input.mousePosition.y * 2 - Screen.height) * hRatio - this.transform.position.y;
            directionAngle = Mathf.Atan2(mY, mX) - Mathf.PI / 2;	//鼠标到角色连线与y轴的夹角
            //moveAnimator.SetFloat(horizontalHash, mX);
            //moveAnimator.SetFloat(verticalHash, mY);

            //动画播放
            if (moveHorizontal == 0 && moveVertical == 0)
            {
                moveAnimator.speed = 0;
            }
            else
            {
                moveAnimator.speed = 1;
            }

            //角色移动
            if ((playerTransform.transform.position.x > moveBorderX && moveHorizontal == 1) || (playerTransform.transform.position.x < -moveBorderX && moveHorizontal == -1))
            {
                moveHorizontal = 0;
            }
            if ((playerTransform.transform.position.y > moveBorderY && moveVertical == 1) || (playerTransform.transform.position.y < -moveBorderY && moveVertical == -1))
            {
                moveVertical = 0;
            }
            moveDirection = new Vector3(moveHorizontal, moveVertical).normalized;
            playerTransform.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            if (modeStartFrame == 0)
            {
                modeStartFrame = MySceneManager.Instance.frameSinceLevelLoad;
            }
            else if ((MySceneManager.Instance.frameSinceLevelLoad - modeStartFrame) > fixedFrame)
            {
                modeManager.SetMoveMode(moveModeNormal);
                modeStartFrame = 0;
                fixedFrame = 1000;
            }
        }
    }

    public override void IsDelayed()
    {
        modeManager.SetMoveMode(moveModeDelay);
    }
}
