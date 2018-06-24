using UnityEngine;
using System.Collections;

public class HitMod_Yuyuko_01 : MonoBehaviour, IHitMode
{
    private PlayerControl playerControl;
    public bool isInvincible;
    public int invincibleTime;
    private int vincibleTime;
    public AudioClip beHitSE;
    private SpriteRenderer playerSprite;
    private PlayerModeManager modeManager;

    // Use this for initialization
    void Awake()
    {
        playerControl = transform.parent.GetComponent<PlayerControl>();
        playerSprite = transform.parent.GetComponent<SpriteRenderer>();
        modeManager = playerControl.modeManager;
        isInvincible = false;
    }

    public void IsHit(int atkPoint, int effect)
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

    public void Hit()
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
