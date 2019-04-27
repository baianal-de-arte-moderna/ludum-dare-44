using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixoScript : MonoBehaviour
{
    SpriteRenderer render;
    Rigidbody2D rigid;
    Collider2D col;
    LixoExplodeScript[] explosionPieces;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            render.enabled = false;
            foreach(var piece in explosionPieces)
            {
                piece.Explode();
            }
        }
    }

    public void Throw(Vector2 direction, float force)
    {
        render.enabled = true;
        rigid.AddForce(direction * rigid.mass * force);
    }
}
