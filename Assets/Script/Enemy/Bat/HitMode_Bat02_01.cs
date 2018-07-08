using UnityEngine;
using System.Collections;

public class HitMode_Bat02_01 : AHitMode
{
    private EnemyControl enemyControl;
    public Transform enemyTransform;

    // Use this for initialization
    void Awake()
    {
        enemyControl = enemyTransform.GetComponent<EnemyControl>();
    }

    public override void IsHit(int atkPoint, int effect)
    {
        enemyControl.enemyHP -= atkPoint;
        UIManager.Instance.scoreText.text = "得分：" + (++UIManager.Instance.score);
    }

    public override void Hit()
    {

    }
}
