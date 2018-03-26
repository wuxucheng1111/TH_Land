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

    Transform fatherCharactor;  //父物体(含有animator)
    Camera mCam;			    //主相机
    Animator moveAnimator;      //角色animator
    int horizontalHash;         //左右参数
    int verticalHash;           //上下参数
    float moveHorizontal;       //左右按键
    float moveVertical;         //上下按键
    Vector3 moveDirection;      //角色移动方向
    private float moveBorderX;
    private float moveBorderY;

    // Use this for initialization
    void Start()
    {
        fatherCharactor = transform.parent;
        mCam = Camera.main;
        moveAnimator = fatherCharactor.GetComponent<Animator>();
        horizontalHash = Animator.StringToHash("AxisX");
        verticalHash = Animator.StringToHash("AxisY");
        moveBorderX = MySceneManager.Instance.GetAreaBorderX() - 0.36f;
        moveBorderY = MySceneManager.Instance.GetAreaBorderY() - 0.36f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        if (fatherCharactor.GetComponent<PlayerControl>().isDead)
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
            moveAnimator.SetFloat(horizontalHash, mX);
            moveAnimator.SetFloat(verticalHash, mY);

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
            if ((fatherCharactor.transform.position.x > moveBorderX && moveHorizontal == 1) || (fatherCharactor.transform.position.x < -moveBorderX && moveHorizontal == -1))
            {
                moveHorizontal = 0;
            }
            if ((fatherCharactor.transform.position.y > moveBorderY && moveVertical == 1) || (fatherCharactor.transform.position.y < -moveBorderY && moveVertical == -1))
            {
                moveVertical = 0;
            }
            moveDirection = new Vector3(moveHorizontal, moveVertical).normalized;
            fatherCharactor.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }        
    }

    float IMoveMode.directionAngle
    {
        get
        {
            return directionAngle;
        }
    }
}
