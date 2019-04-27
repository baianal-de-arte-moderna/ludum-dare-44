using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InimigoBaseScript))]
public class CachorroScript : MonoBehaviour
{
    enum CachorroStates 
    {
        WAITING,
        RUNNING,
        ATTACKING
    }
    InimigoBaseScript inimigoBase;
    CachorroStates state;
    Rigidbody2D rigid;
    void Awake()
    {
        inimigoBase = GetComponent<InimigoBaseScript>();
        rigid = GetComponent<Rigidbody2D>();
        state = CachorroStates.WAITING;
    }

    void FixedUpdate()
    {
        if (state == CachorroStates.RUNNING)
        {
            rigid.velocity = new Vector2(-inimigoBase.speed, rigid.velocity.y);
        }
    }

    void OnBecameVisible()
    {
        state = CachorroStates.RUNNING;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
