using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public APlayerModeManager modeManager;
    public float playerSize { get { return modeManager.playerSize; } }     //角色判定半径
    public int maxPlayHP;
    public int playerHP;
    public Image HPbar;
    public bool isDead;
    private Animator playerAnimator;
    public AudioClip dieSE;

    // Use this for initialization
    void Awake()
    {
        playerHP = maxPlayHP;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        HPbar.fillAmount = (float)playerHP / (float)maxPlayHP;
    }
    void IsAlive()
    {
        if (isDead)
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

}
