using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FundoParallaxScript : MonoBehaviour
{
    SpriteRenderer render;
    public int layer;
    public Vector3 direction;
    const float SPEED = 1f;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();      
        render.sortingOrder = -100 - layer;
    }

    void FixedUpdate()
    {
        transform.position += direction * (SPEED / layer);
    }
}
