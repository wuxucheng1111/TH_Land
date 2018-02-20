using UnityEngine;
using System.Collections;

public class Enemy_BatLauncher01 : Launcher {

    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public int chargeFront;                 //攻击前摇
    public int chargeBack;                  //攻击后摇
    public GameObject Target;               //攻击目标(自机狙)

    //int chargeFrontCount;                   //前摇计数
    //int chargeBackCount;                    //后摇计算点

	// Use this for initialization
	void Start () {
        if (BullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        //chargeFrontCount = 0;
        //chargeBackCount = -chargeBack - (bullentWave - 1) * waveInterval;   //保证开始时能进行发射
	}
	
	// Update is called once per frame
    void Update()
    {
        if (BullentType == null)
        {
            return;
        }
    }


    public override void Launch()
    {
        throw new System.NotImplementedException();
    }
}
