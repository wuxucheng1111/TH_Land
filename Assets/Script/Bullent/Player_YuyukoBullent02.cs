using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player_YuyukoBullent02 : MonoBehaviour
{
    public float velocity;                  //弹幕速度
    public float acceleration;              //弹幕加速度
    public float rotationVelocity;          //自转速度
    public int life;                        //弹幕生存时间
    public int attackPoint;                 //弹幕攻击力
    public bool isTrack;                    //是否追尾弹
    public GameObject hitEffect;            //命中特效

    public float bullentWidth;              //激光判定宽度
    public float bullentLength;             //激光判定长度(无缩放长度)
    public int maxFrame;                    //激光到极限长度的帧数
    public int interval;                    //判定间隔

    int startTime;                          //弹幕产生的时间点
    List<GameObject> enemies;               //场景中敌人列表
    public int effect;                      //攻击效果

    Dictionary<GameObject, int> hitEnemies; //被攻击的敌人与判定间隔
    List<GameObject> hitEnemiesList;        //用于更改敌人与判定间隔字典
    int existFrame;                         //弹幕已存在的帧数

    // Use this for initialization
    void Start()
    {
        startTime = MySceneManager.Instance.frameSinceLevelLoad;
        enemies = MySceneManager.Instance.enemies;
        hitEnemies = new Dictionary<GameObject, int>();
        hitEnemiesList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        existFrame = MySceneManager.Instance.frameSinceLevelLoad - startTime;
        if (existFrame > life)
        {
            Destroy(gameObject);
        }
        //处理判定间隔
        hitEnemiesList = hitEnemies.Keys.ToList();
        foreach (GameObject e in hitEnemiesList)
        {
            hitEnemies[e] -= 1;
            if (hitEnemies[e] < 1)
            {
                hitEnemies.Remove(e);
            }
        }

        CollisionDet();
        transform.localScale = new Vector3(1, Mathf.Min(existFrame, maxFrame) * velocity, 1);
    }

    void CollisionDet()
    {
        for (int index = 0; index < enemies.Count; index++)
        {
            float x = enemies[index].transform.position.x - transform.position.x;
            float y = enemies[index].transform.position.y - transform.position.y;
            float enemySize = enemies[index].GetComponent<EnemyControl>().enemySize;
            if (Vector3.Angle(new Vector3(x, y, 0), transform.up) < 90)
            {
                if (Mathf.Abs(x * Mathf.Sin((transform.eulerAngles.z + 90) * Mathf.Deg2Rad) - y * Mathf.Cos((transform.eulerAngles.z + 90) * Mathf.Deg2Rad)) < (bullentWidth + enemySize))    //点到直线距离 abs((x-x0）sin a-(y-y0)cos a)
                {
                    if ((transform.position - enemies[index].transform.position).magnitude < transform.localScale.y * bullentLength)
                    {
                        if (enemies[index].GetComponent<EnemyControl>().isDead == false && !hitEnemies.ContainsKey(enemies[index]))
                        {
                            GameObject eff = Instantiate(hitEffect, transform, false) as GameObject;
                            eff.transform.position = transform.position + transform.up * (Vector3.Magnitude(enemies[index].transform.position - transform.position + new Vector3(0, 0, transform.position.z)) - enemySize / 2);
                            eff.transform.SetParent(enemies[index].transform, true);
                            eff.transform.localScale = Vector3.one;
                            enemies[index].GetComponent<EnemyControl>().enemyModeManager.enemyHitMode.IsHit(attackPoint, effect);
                            hitEnemies.Add(enemies[index], interval);
                        }
                    }
                }
            }
        }
    }
}
