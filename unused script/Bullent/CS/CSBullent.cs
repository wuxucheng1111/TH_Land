using UnityEngine;
using System.Collections;

public class CSBullent : MonoBehaviour
{
    #region 初始参数
    public float bullentVelocityDirection;
    /// <summary>
    /// 子弹
    /// </summary>
    public int bullentLife;
    public string bullentType;
    public Vector2 bullentRatio;
    public Vector3 bullentColour;
    public int bullentAlpha;
    public float bullentDirection;
    /// <summary>
    /// 子弹运动
    /// </summary>
    public float bullentVelocity;
    public float bullentAcceleration;
    public float bullentAccelerationDirection;
    public Vector2 bullentVelocityRatio;
    #endregion

    private int currentBullentLife;                     //弹幕已经存活了的帧数
    private Vector3 currentBullentVelocity;             //弹幕当前速度
    private Vector3 currentBullentAcceleration;         //弹幕当前加速度
    private Vector3 currentBullentVelocityDirection;    //弹幕当前速度方向，由currentBullentVelocity得出，向上为0


    public CSBullent(float bullentVelocityDirection,int bullentLife,string bullentType,Vector2 bullentRatio,Vector3 bullentColour,int bullentAlpha,float bullentDirection,float bullentVelocity,float bullentAcceleration,float bullentAccelerationDirection,Vector2 bullentVelocityRatio)
    {
        this.bullentVelocityDirection = bullentVelocityDirection;
        this.bullentLife = bullentLife;
        this.bullentType = bullentType;
        this.bullentRatio = bullentRatio;
        this.bullentColour = bullentColour;
        this.bullentAlpha = bullentAlpha;
        this.bullentDirection = bullentDirection;
        this.bullentVelocity = bullentVelocity;
        this.bullentAcceleration = bullentAcceleration;
        this.bullentAccelerationDirection = bullentAccelerationDirection;
        this.bullentVelocityRatio = bullentVelocityRatio;
    }

	// Use this for initialization
	void Start () {
        currentBullentLife = 0;
        currentBullentVelocity = new Vector3(bullentVelocity * Mathf.Cos(-bullentVelocityDirection * Mathf.Deg2Rad), bullentVelocity * Mathf.Sin(-bullentVelocityDirection * Mathf.Deg2Rad), 0);
        currentBullentAcceleration = new Vector3(bullentAcceleration * Mathf.Cos(-bullentAccelerationDirection * Mathf.Deg2Rad), bullentAcceleration * Mathf.Sin(-bullentAccelerationDirection * Mathf.Deg2Rad), 0);
        //currentBullentVelocityDirection = new Vector3(0, 0, -bullentVelocityDirection - 90);
        //transform.rotation = Quaternion.Euler(currentBullentVelocityDirection);
	}
	
	// Update is called once per frame
	void Update () {
        if (currentBullentLife < bullentLife)
        {
            currentBullentVelocityDirection = new Vector3(0, 0, Mathf.Atan2(currentBullentVelocity.y, currentBullentVelocity.x) * Mathf.Rad2Deg-90);
            transform.rotation = Quaternion.Euler(currentBullentVelocityDirection);
            transform.Translate(currentBullentVelocity,Space.World);
            currentBullentVelocity += currentBullentAcceleration;
            currentBullentLife++;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
