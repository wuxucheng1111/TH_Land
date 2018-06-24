using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_YuyukoBullent01 : MonoBehaviour
{
    public float velocity;              //弹幕速度
    public float acceleration;          //弹幕加速度
    public float rotationVelocity;      //自转速度
    public int life;                    //弹幕生存时间
    public int attackPoint;             //弹幕攻击力
    public float bullentSize;           //攻击判定半径
    public bool isTrack;                //是否追尾弹
    public GameObject hitEffect;        //命中特效

    Vector3 direction;                  //实际速度方向
    int startTime;                      //弹幕产生的时间点
    public List<GameObject> enemies;    //场景中敌人列表
    public int effect;                  //攻击效果

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
        for (int index = 0; index < enemies.Count; index++)
        {
            if ((transform.position - new Vector3(0, 0, transform.position.z) - enemies[index].transform.position).magnitude < (bullentSize + enemies[index].GetComponent<EnemyControl>().enemySize) && enemies[index].GetComponent<EnemyControl>().isDead == false)
            {
                if (enemies[index].GetComponent<EnemyControl>().enemyModeManager.enemyHitMode != null)
                {
                    enemies[index].GetComponent<EnemyControl>().enemyModeManager.enemyHitMode.IsHit(attackPoint, effect);
                    Instantiate(hitEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else
                    Debug.Log("bullent");
            }
        }
    }
}
