using UnityEngine;
using System.Collections;

public class Enemy_BatBullent01 : MonoBehaviour
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
    GameObject player;                  //玩家

    // Use this for initialization
    void Start()
    {
        player = MySceneManager.Instance.player;
        startTime = MySceneManager.Instance.frameSinceLevelLoad;
        direction = new Vector3(-velocity * Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), velocity * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0);
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
        if ((transform.position - player.transform.position).magnitude < (player.GetComponent<PlayerControl>().playerSize + bullentSize))
        {
            player.GetComponent<PlayerControl>().playerHP--;
            UIManager.Instance.hitCountText.text = "中弹数：" + (++UIManager.Instance.hitCount);
            Destroy(gameObject);
        }
    }
}
