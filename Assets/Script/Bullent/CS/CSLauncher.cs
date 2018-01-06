using UnityEngine;
using System.Collections;

public class CSLauncher : MonoBehaviour
{
    #region 层参数
    public int layerLoopFrame;  //应>=basicStartTime+basicDuration-1
    #endregion

    #region 弹幕参数
    /// <summary>
    /// 基本
    /// </summary>
    public int basicStartTime;
    public int basicDuration;
    /// <summary>
    /// 发射器运动
    /// </summary>
    public float launcherVelocity;
    public float launcherVelocityDirection;
    public float launcherAcceleration;
    public float launcherAccelerationDirection;
    /// <summary>
    /// 发射
    /// </summary>
    public Vector3 launchingPosition;
    public float launchingRadius;
    public float launchingDirection;
    public int launchingQuantity;
    public int launchingCycle;
    public float launchingAngle;
    public float launchingRange;
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

    private int startFrame;
    private int currentFrame;   //循环中的当前帧数
    private GameObject bullent;

    void Start()
    {
        startFrame = Time.frameCount;
        bullent = Resources.Load("Prefab/" + bullentType, typeof(GameObject)) as GameObject;
        Debug.Log(bullent);
    }

    void Update()
    {
        currentFrame = Time.frameCount - startFrame + 1;
        if (currentFrame > layerLoopFrame)  //超过循环帧数后，弹幕重复循环
        {
            startFrame = Time.frameCount;
            currentFrame = 1;
        }
        if (currentFrame >= basicStartTime && currentFrame <= basicDuration)
        {
            Launch();
        }
    }
    void Launch()
    {
        if (launchingCycle == 1 || currentFrame % launchingCycle == 1)
        {
            for (int n = 1; n < launchingQuantity + 1; n++)
            {
                float theta = (launchingQuantity + 1 - 2 * n) * launchingRange / (2 * launchingQuantity);
                float bullentVelocityDirection = theta + launchingAngle;
                Vector3 bullentStartPosition = new Vector3(launchingRadius * Mathf.Cos((theta + launchingDirection) * Mathf.Deg2Rad), launchingRadius * Mathf.Sin(-(theta + launchingDirection) * Mathf.Deg2Rad), 0);
                GameObject bullentInst = Instantiate(bullent);
                bullentInst.transform.position = transform.position + bullentStartPosition;
                bullentInst.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -bullentVelocityDirection - 90));
                CSBullent bullentComponent = bullentInst.GetComponent<CSBullent>();
                bullentComponent.bullentVelocityDirection = bullentVelocityDirection;
                bullentComponent.bullentLife = bullentLife;
                bullentComponent.bullentColour = bullentColour;
                bullentComponent.bullentAlpha = bullentAlpha;
                bullentComponent.bullentDirection = bullentDirection;
                bullentComponent.bullentVelocity = bullentVelocity;
                bullentComponent.bullentAcceleration = bullentAcceleration;
                bullentComponent.bullentAccelerationDirection = bullentAccelerationDirection;
                bullentComponent.bullentVelocityRatio = bullentVelocityRatio;
            }
        }
    }
}