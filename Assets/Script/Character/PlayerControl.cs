using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public PlayerState playerState;
    public float playerSize { get { return playerState.GetPlayerSize(); } }     //角色判定半径
    public int maxPlayHP;
    public int playerHP;
    public Image HPbar;
    public bool isDead;
    private Animator playerAnimator;
    public AudioClip dieSE;
    public AudioClip beHitSE;
    public int invincibleTime;
    private int vincibleTime;
    public bool isInvincible;
    private SpriteRenderer playerSprite;

    // Use this for initialization
    void Start()
    {
        playerHP = maxPlayHP;
        playerAnimator = GetComponent<Animator>();
        isInvincible = false;
        vincibleTime = MySceneManager.Instance.frameSinceLevelLoad;
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        playerState.Move();
        playerState.Attack();
        HPbar.fillAmount = (float)playerHP / (float)maxPlayHP;
        Invincible();
    }
    void IsAlive()
    {
        if (isDead == true)
        {
            AnimatorStateInfo playerAniInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Player_Die") && playerAniInfo.normalizedTime > 1.0f)
            {
                gameObject.SetActive(false);
            }
            return;
        }
        if (playerHP < 1)
        {
            MySceneManager.Instance.player.Remove(gameObject);
            playerAnimator.SetBool("isDead", true);
            isDead = true;
            AudioSource.PlayClipAtPoint(dieSE, transform.position);
        }
    }

    public void IsHit(int atkPoint)
    {
        if (isInvincible == false)
        {
            playerHP -= atkPoint;
            isInvincible = true;
            vincibleTime = MySceneManager.Instance.frameSinceLevelLoad + invincibleTime;
            AudioSource.PlayClipAtPoint(beHitSE, transform.position);
        }
    }
    void Invincible()
    {
        if (isInvincible == true)
        {
            if ((MySceneManager.Instance.frameSinceLevelLoad - vincibleTime + invincibleTime) % 10 == 1)
            {
                playerSprite.color = new Color(1, 1, 1, 0.5f);
            }
            if ((MySceneManager.Instance.frameSinceLevelLoad - vincibleTime + invincibleTime) % 10 == 6)
            {
                playerSprite.color = new Color(1, 1, 1, 1);
            }
            if (MySceneManager.Instance.frameSinceLevelLoad > vincibleTime)
            {
                isInvincible = false;
                playerSprite.color = new Color(1, 1, 1, 1);
            }
        }

    }
}
