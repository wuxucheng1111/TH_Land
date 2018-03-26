using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_YuyukoBullent01 : MonoBehaviour
{
    public float velocity;              //弹幕速度
    public float acceleration;          //弹幕加速度
    public float rotationVelocity;      //自转速度
    public int life;                    //弹幕生存时间
    public float attackPoint;           //弹幕攻击力
    public float bullentSize;           //攻击判定半径
    public bool isTrack;                //是否追尾弹

    Vector3 direction;                  //实际移动速度
    int startTime;                      //弹幕产生的时间点
    public List<GameObject> enemies;    //场景中敌人列表

    // Use this for initialization
    void Start()
    {
        startTime = MySceneManager.Instance.frameSinceLevelLoad;
        direction = new Vector3(-velocity * Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), velocity * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0);
        enemies = MySceneManager.Instance.enemies;
    }

    // Update is called once per frame
    void Update()
    {
        if ((MySceneManager.Instance.frameSinceLevelLoad - startTime) > life)
        {
            Destroy(gameObject);
        }
        CollisionDet();
        transform.Translate(direction * Time.deltaTime, Space.World);
    }

    void CollisionDet()
    {
        if (enemies.Count == 0)
            return;
        for (int index = 0; index < enemies.Count; index++)
        {
            if ((transform.position - enemies[index].transform.position).magnitude < (bullentSize + enemies[index].GetComponent<EnemyControl>().enemySize) && enemies[index].GetComponent<EnemyControl>().isDead != true)
            {
                UIManager.Instance.scoreText.text = "得分：" + (++UIManager.Instance.score);
                enemies[index].GetComponent<EnemyControl>().enemyHP--;
                Destroy(gameObject);
            }
        }
    }
}
