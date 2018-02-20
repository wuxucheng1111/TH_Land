using UnityEngine;
using System.Collections;

public class EnemyAI_Bat : MonoBehaviour
{
    public IEnemyState bat02_State;
    // Use this for initialization
    void Start()
    {
        bat02_State = GetComponent<Enemy_Bat_NormalState>();
    }

    // Update is called once per frame
    void Update()
    {
        bat02_State.Move();
        bat02_State.Attack();
    }
}
