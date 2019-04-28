﻿using UnityEngine;
using System.Collections;

public abstract class JumpBehaviour
{
    public void Jump(Rigidbody2D rigid, PlayerAttributes playerAttributes)
    {
        rigid.velocity = new Vector2(rigid.velocity.x, JumpModifier() * playerAttributes.speed * rigid.gravityScale / 2);
    }

    abstract public float GetPrice();

    abstract protected float JumpModifier();
}
