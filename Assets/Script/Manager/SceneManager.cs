using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : SingletonTemplate<SceneManager>
{
    public GameObject player;
    public List<GameObject> enemies;
    public Points points;
    public List<int> spawnTime;
    private int spawnIndex = 0;

    void Awake()
    {
        player = (GameObject)Instantiate(Resources.Load("Prefabs/Player_Yuyuko"));
        player.transform.parent = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (spawnIndex < spawnTime.Count && Time.frameCount > spawnTime[spawnIndex])
        {
            Point spawnPoint = points.GetNextPoint(true);
            if (spawnPoint != null)
            {
                GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/Bat02"), spawnPoint.position, spawnPoint.rotation);
                enemies.Add(enemy);
            }
            spawnIndex++;
        }
    }
}
