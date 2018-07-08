using UnityEngine;
using System.Collections;

public class HitMod_Yuyuko_01 : AHitMode
{
    private PlayerControl playerControl;
    [HideInInspector]
    public bool isInvincible;
    public int invincibleTime;
    private int vincibleTime;
    public AudioClip beHitSE;
    private SpriteRenderer playerSprite;
    private APlayerModeManager modeManager;
    public Transform playerTransform;

    // Use this for initialization
    void Awake()
    {
        playerControl = playerTransform.GetComponent<PlayerControl>();
        playerSprite = playerTransform.GetComponent<SpriteRenderer>();
        modeManager = playerControl.modeManager;
        isInvincible = false;
    }

    public override void IsHit(int atkPoint, int effect)
    {
        if (isInvincible == false)
        {
            playerControl.playerHP -= atkPoint;
            UIManager.Instance.hitCountText.text = "中弹数：" + (++UIManager.Instance.hitCount);
            isInvincible = true;
            vincibleTime = MySceneManager.Instance.frameSinceLevelLoad + invincibleTime;
            AudioSource.PlayClipAtPoint(beHitSE, transform.position);
        }
        switch (effect)
        {
            case 1:
                modeManager.playerMoveMode.IsDelayed();
                break;
            default:
                break;
        }
    }

    public override void Hit()
    {
        if (isInvincible)
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
