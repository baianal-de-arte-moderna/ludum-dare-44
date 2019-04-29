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
    int direction;
    Vector3 originalScale;
    void Awake()
    {
        inimigoBase = GetComponent<InimigoBaseScript>();
        rigid = GetComponent<Rigidbody2D>();

        originalScale = transform.localScale;

        state = CachorroStates.WAITING;
        direction = -1;
    }

    void FixedUpdate()
    {
        direction = rigid.velocity.x > 1f? 1: -1;
        transform.localScale = new Vector3(
            originalScale.x * -direction,
            originalScale.y,
            1f);

        if (state == CachorroStates.RUNNING)
        {
            rigid.velocity = new Vector2(inimigoBase.speed * direction, rigid.velocity.y);
        } 
        else if (state == CachorroStates.ATTACKING)
        {
            TriggerCollider.enabled = false;
            var leapForce = LeapDirection.normalized * inimigoBase.speed * rigid.mass * 100f;
            leapForce.x *= direction;
            rigid.AddForce(leapForce);
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

    // void OnBecameInvisible()
    // {
        // Destroy(gameObject);
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerCollider.enabled = false;
            state = CachorroStates.ATTACKING;
        }
        if (other.CompareTag("KillPlane"))
        {
            Destroy(gameObject);
        }
    }
}
