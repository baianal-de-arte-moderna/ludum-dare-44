using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoScript : MonoBehaviour
{
    SpriteRenderer render;
    Rigidbody2D rigid;
    Collider2D col;
    public LixoExplodeScript[] explosionPieces;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        col.enabled = false;
        render.enabled = false;
        foreach(var piece in explosionPieces)
        {
            piece.Explode();
        }
    }

    void EnableCollider()
    {
        col.enabled = true;
    }

    public void Throw(Vector2 direction, float force)
    {
        render.enabled = true;
        rigid.AddForce(direction * rigid.mass * force);
    }
}
