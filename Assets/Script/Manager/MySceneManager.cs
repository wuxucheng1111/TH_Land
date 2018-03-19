using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MySceneManager : SingletonTemplate<MySceneManager>
{
    public GameObject player;
    private PlayerControl playerControl;
    public List<GameObject> enemies;
    public Points points;
    public List<int> spawnTime;
    private int spawnIndex = 0;

    public GameObject playerObj;
    public GameObject enemiesObj;
    public GameObject playerBullentsObj;
    public GameObject enemyBullentsObj;

    public float areaBorderX;
    public float areaBorderY;

    private int frameZero;
    public int frameSinceLevelLoad { get { return Time.frameCount - frameZero; } }

    void Awake()
    {
        Time.timeScale = 1;
        //player = (GameObject)Instantiate(Resources.Load("Prefabs/Player_Yuyuko"));
        player = Instantiate(player);
        player.transform.parent = playerObj.transform;
    }
    void Start()
    {
        playerControl = player.GetComponent<PlayerControl>();
        frameZero = Time.frameCount;
    }
    void Update()
    {
        EnemySpawn();
        IsGameOver();
    }

    void EnemySpawn()
    {
        if (spawnIndex < spawnTime.Count && frameSinceLevelLoad > spawnTime[spawnIndex])
        {
            Point spawnPoint = points.GetNextPoint(true);
            if (spawnPoint != null)
            {
                GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Bat02"), spawnPoint.position, spawnPoint.rotation);
                enemy.transform.parent = enemiesObj.transform;
                enemies.Add(enemy);
            }
            spawnIndex++;
        }
    }

    public float GetAreaBorderX()
    {
        return areaBorderX;
    }
    public float GetAreaBorderY()
    {
        return areaBorderY;
    }
    void IsGameOver()
    {
        if (playerControl.playerHP < 1)
        {
            Animator playerAni = player.GetComponent<Animator>();
            playerAni.SetBool("isDead", true);
            AnimatorStateInfo playerAniInfo=playerAni.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Player_Die") && playerAniInfo.normalizedTime > 1.0f)
            {
                player.SetActive(false);
                UIManager.Instance.UIGameOver();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Profeb Scene");
    }
}
