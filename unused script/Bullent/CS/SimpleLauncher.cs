using UnityEngine;
using System.Collections;

public class SimpleLauncher : MonoBehaviour
{
    /// <summary>
    /// 子弹prefab
    /// </summary>
    public GameObject simpleBullentType;
    /// <summary>
    /// 发射前摇
    /// </summary>
    public float cradleFront;
    /// <summary>
    /// 发射后摇
    /// </summary>
    public float cradleAfter;
    /// <summary>
    /// 反复发射间隔
    /// </summary>
    public float repeatInterval;
    /// <summary>
    /// 一波发射数量
    /// </summary>
    public int bullentNumber;
    /// <summary>
    /// 相对自身的发射位置
    /// </summary>
    public Vector3 launchRelativePostion;
    /// <summary>
    /// 子弹速度
    /// </summary>
    public Vector3 Velocity;
    /// <summary>
    /// 子弹加速度
    /// </summary>
    public Vector3 Acceleration;
    /// <summary>
    /// 瞄准的目标
    /// </summary>
    public Transform target;

    //Vector3 launchPostion;  //实际发射位置

    // Use this for initialization
    void Start()
    {
        //launchPostion = transform.position + launchRelativePostion;
        if (target != null)
        {
        
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire()
    {

    }
}
