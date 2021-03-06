﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoExplodeScript : MonoBehaviour
{
    SpriteRenderer render;
    Rigidbody2D rigid;
    Vector2 direction;
    float force;
    float vanishSpeed;
    bool active;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();

        direction = Random.insideUnitCircle;
        direction = new Vector2(
            direction.x,
            Mathf.Abs(direction.y)
        ).normalized;
        force = 400f;
        vanishSpeed = Random.Range(0.015f, 0.02f);
        active = false;
    }

    void FixedUpdate()
    {
        if (active)
        {
            render.color = Color.Lerp (
                render.color,
                Color.clear,
                vanishSpeed
            );
            if (render.color.a < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Explode()
    {
        render.enabled = true;
        transform.position = transform.parent.position;
        rigid.WakeUp();
        rigid.AddForce(direction * rigid.mass * force);
        active = true;
    }
}
