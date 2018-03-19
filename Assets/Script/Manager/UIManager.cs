using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : SingletonTemplate<UIManager>
{
    public int score;
    public int playerHP;
    public int hitCount;
    public Text hitCountText;
    public Text scoreText;
    public GameObject buttonGameOver;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UIGameOver()
    {
        buttonGameOver.SetActive(true);
    }
}
