using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MySceneManager : SingletonTemplate<MySceneManager>
{
    public List<GameObject> player;
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
        for (int i = 0; i < player.Count; i++)
        {
            player[i] = Instantiate(player[i]);
            player[i].transform.parent = playerObj.transform;
        }
    }
    void Start()
    {

        frameZero = Time.frameCount;
    }
    void Update()
    {
        if (player.Count==0)
        {
            Invoke("GameOver", 1f);
        }
        EnemySpawn();        
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
    void GameOver()
    {        
        UIManager.Instance.UIGameOver();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Profeb Scene");
    }
}
