using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_HPUp : MonoBehaviour
{
    public int HP;
    public float itemSize;
    public AudioClip Item_HPUpSE;
    private List<GameObject> player;

    void Awake()
    {
        player = MySceneManager.Instance.player;
    }

    void Update()
    {
        CollisionDet();
    }

    void CollisionDet()
    {
        for (int i = 0; i < player.Count; i++)
        {
            if ((transform.position - player[i].transform.position).magnitude < (player[i].GetComponent<PlayerControl>().playerSize + itemSize))
            {
                if ((player[i].GetComponent<PlayerControl>().playerHP + HP) > player[i].GetComponent<PlayerControl>().maxPlayHP)
                {
                    player[i].GetComponent<PlayerControl>().playerHP = player[i].GetComponent<PlayerControl>().maxPlayHP;
                }
                else
                {
                    player[i].GetComponent<PlayerControl>().playerHP += HP;
                }
                AudioSource.PlayClipAtPoint(Item_HPUpSE, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
