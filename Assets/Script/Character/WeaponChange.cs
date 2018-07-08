using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponChange : MonoBehaviour {

    //IAttackMode attackMode;
    private List<GameObject> player;
    
    void Awake()
    {
        player = MySceneManager.Instance.player;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CollisionDet()
    {
        for (int i = 0; i < player.Count; i++)
        {
            if ((transform.position - player[i].transform.position).magnitude < (player[i].GetComponent<PlayerControl>().playerSize + 1111111111))
            {
                //player[i].GetComponent<PlayerControl>().modeManager.SetAttackMode(attackMode);
                Destroy(gameObject);
            }
        }
    }
}
