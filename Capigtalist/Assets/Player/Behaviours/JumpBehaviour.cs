using UnityEngine;
using System.Collections;

public abstract class JumpBehaviour : MonoBehaviour
{
    public void Jump(Rigidbody2D rigid, PlayerAttributes playerAttributes)
    {
        rigid.velocity = new Vector2(rigid.velocity.x, JumpModifier() * playerAttributes.speed * rigid.gravityScale / 2);
    }

    abstract protected float JumpModifier();
}
