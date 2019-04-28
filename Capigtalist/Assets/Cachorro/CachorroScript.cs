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
    public Vector2 LeapDirection;
    public Collider2D TriggerCollider;
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
        else if (state == CachorroStates.ATTACKING)
        {
            TriggerCollider.enabled = false;
            rigid.AddForce(LeapDirection.normalized * inimigoBase.speed * rigid.mass * 100f);
            state = CachorroStates.WAITING;
            // Temporary animation resume by timing
            // Later on will be controlled by Animator
            Invoke("LeapEnd", 1.2f);
        }
    }

    void LeapEnd()
    {
        state = CachorroStates.RUNNING;
        TriggerCollider.enabled = true;
    }

    void OnBecameVisible()
    {
        state = CachorroStates.RUNNING;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerCollider.enabled = false;
            state = CachorroStates.ATTACKING;
        }
    }
}
