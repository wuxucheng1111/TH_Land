using UnityEngine;
using System.Collections;

public class HitMode_Bat02_01 : MonoBehaviour, IHitMode
{
    private EnemyControl enemyControl;

    // Use this for initialization
    void Awake()
    {
        enemyControl = transform.parent.GetComponent<EnemyControl>();
    }

    public void IsHit(int atkPoint, int effect)
    {
        enemyControl.enemyHP -= atkPoint;
        UIManager.Instance.scoreText.text = "得分：" + (++UIManager.Instance.score);
    }

    public void Hit()
    {

    }
}
