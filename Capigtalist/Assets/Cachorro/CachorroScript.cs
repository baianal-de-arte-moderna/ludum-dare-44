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
    Animator anim;
    public Vector2 LeapDirection;
    public Collider2D TriggerCollider;
    int direction;
    Vector3 originalScale;
    void Awake()
    {
        inimigoBase = GetComponent<InimigoBaseScript>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        originalScale = transform.localScale;

        state = CachorroStates.WAITING;
        anim.Play("Idle");
        direction = -1;
    }

    void FixedUpdate()
    {
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
            anim.Play("Idle");
            Invoke("LeapEnd", 1.2f);
        }
    }

    void LeapEnd()
    {
        state = CachorroStates.RUNNING;
        anim.Play("Run");
        TriggerCollider.enabled = true;
    }

    void OnBecameVisible()
    {
        state = CachorroStates.RUNNING;
        anim.Play("Run");
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
            anim.Play("Attack");
        }
        if (other.CompareTag("KillPlane"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Mathf.Abs(other.contacts[0].normal.x) >= 0.9f)
        {
            direction = (int)Mathf.Sign(other.contacts[0].normal.x);
        }
    }
}
