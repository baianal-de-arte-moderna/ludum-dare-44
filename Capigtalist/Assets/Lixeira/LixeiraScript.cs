using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixeiraScript : MonoBehaviour
{
    enum LixeiraStates 
    {
        WAITING,
        ATTACKING
    }
    InimigoBaseScript inimigoBase;
    LixeiraStates state;
    Rigidbody2D rigid;
    Vector2 AttackDirection;
    float AttackForce;
    float AttackForceConstant;
    public Collider2D TriggerCollider;

    [Header("Bullet Properties")]
    [Space(15)]
    public GameObject Bullet;
    public float AttackCooldownTime;
    public float ThrowHeight;

    void Awake()
    {
        inimigoBase = GetComponent<InimigoBaseScript>();
        rigid = GetComponent<Rigidbody2D>();
        state = LixeiraStates.WAITING;
        AttackForceConstant = ThrowHeight * rigid.gravityScale * Physics.gravity.y;
    }

    void FixedUpdate()
    {
        if (state == LixeiraStates.ATTACKING)
        {
            TriggerCollider.enabled = false;
            state = LixeiraStates.WAITING;
            Attack();
            Invoke("Cooldown", AttackCooldownTime);
        }
    }
    void Attack()
    {
        var b = Instantiate(Bullet, transform.position + Vector3.up, Quaternion.identity);
        b.GetComponent<LixoScript>().Throw(AttackDirection, AttackForce); 
    }

    void Cooldown()
    {
        TriggerCollider.enabled = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        TriggerCollider.enabled = false;
        // Lock on player
        var distance = other.transform.position.x - transform.position.x;
        AttackDirection = new Vector2(
            distance,
            ThrowHeight
        ).normalized;
        AttackForce = Mathf.Abs(AttackForceConstant * distance);
        
        state = LixeiraStates.ATTACKING;
    }
}
