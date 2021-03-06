﻿using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerAttributes))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private InputType input;

    private Rigidbody2D rigid;
    private PlayerAttributes playerAttributes;
    private SpriteRenderer playerRenderer;
    private PlayerFeetScript feet;
    private SpriteRenderer upgrade1Renderer;

    private JumpBehaviour jumpBehaviour;

    private bool grounded
    {
        get
        {
            return feet.grounded;
        }
    }

    private void Awake()
    {
        feet = GetComponentInChildren<PlayerFeetScript>();
        rigid = GetComponent<Rigidbody2D>();
        playerAttributes = GetComponent<PlayerAttributes>();
        playerRenderer = GetComponent<SpriteRenderer>();

        jumpBehaviour = GameData.jumpBehaviour;
        GameObject.FindGameObjectWithTag("Upgrade").GetComponent<SpriteRenderer>().enabled = GameData.springUpdate;
    }

    private void Start()
    {
        input.OnJumpInputEvent += OnJump;
        input.OnMoveLeftInputEvent += OnMoveLeft;
        input.OnMoveRightInputEvent += OnMoveRight;
        input.OnMoveStopInputEvent += OnMoveStop;
        playerAttributes.OnPlayerDeath += Die;
        feet.onBounce += OnJump;
        if (GameObject.FindGameObjectWithTag("Upgrade") != null)
        {
            upgrade1Renderer = GameObject.FindGameObjectWithTag("Upgrade").GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillPlane"))
        {
            Die();
        }
    }

    public Vector2 GetCenter()
    {
        return playerRenderer.bounds.center;
    }

    private void OnJump()
    {
        if (grounded)
        {
            jumpBehaviour.Jump(rigid, playerAttributes);
        }
    }

    private void OnMoveLeft()
    {
        rigid.velocity = new Vector2(-playerAttributes.speed, rigid.velocity.y);
        playerRenderer.flipX = true;
        upgrade1Renderer.flipX = true;
    }

    private void OnMoveRight()
    {
        rigid.velocity = new Vector2(playerAttributes.speed, rigid.velocity.y);
        playerRenderer.flipX = false;
        upgrade1Renderer.flipX = false;
    }

    private void OnMoveStop()
    {
        rigid.velocity = new Vector2(Mathf.Lerp(rigid.velocity.x, 0f, 0.1f), rigid.velocity.y);
    }

    public void Die()
    {
        playerAttributes.hp = GameData.startHp;
        SceneManager.LoadScene("GameOverScene");
    }
}
