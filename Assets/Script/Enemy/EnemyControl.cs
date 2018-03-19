using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    public int enemyHP;
    public EnemyState enemyState;
    public float enemySize { get { return enemyState.GetEnemySize(); } }       //敌人判定半径

    Animator enemyAnimator;
    AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <1)
        {
            enemyAnimator.SetBool("isDead", true);
        }
        else
        {
            enemyState.Move();
            enemyState.Attack();
        }
        stateInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsTag("Disappear") && stateInfo.normalizedTime >= 1)
        {
            MySceneManager.Instance.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
