using UnityEngine;
using System.Collections;

public abstract class AMoveMode : MonoBehaviour
{
    /// <summary>
    /// 角色移动速度
    /// </summary>
    public float moveSpeed;
    [HideInInspector]
    /// <summary>
    /// 鼠标到角色连线与y轴的夹角
    /// </summary>
    public float directionAngle;
    public abstract void Move();
    public abstract void IsDelayed();
}
