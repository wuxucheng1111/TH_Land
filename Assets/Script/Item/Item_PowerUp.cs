using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item_PowerUp : MonoBehaviour
{
    public int power;
    public float itemSize;
    public AudioClip Item_PowerUpSE;
    private List<GameObject> player;

    void Awake()
    {
        player = MySceneManager.Instance.player;
    }

    // Update is called once per frame
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
                player[i].GetComponent<PlayerControl>().modeManager.playerAttackMode.PowerUp(power);
                AudioSource.PlayClipAtPoint(Item_PowerUpSE, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
