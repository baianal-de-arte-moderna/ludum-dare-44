using UnityEngine;

[RequireComponent(typeof(PlayerAttributes))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private InputType input;

    private Rigidbody2D rigid;
    private PlayerAttributes playerAttributes;
    private SpriteRenderer playerRenderer;

    private bool grounded;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAttributes = GetComponent<PlayerAttributes>();
        playerRenderer = GetComponent<SpriteRenderer>();

        input.OnJumpInputEvent += OnJump;
        input.OnMoveLeftInputEvent += OnMoveLeft;
        input.OnMoveRightInputEvent += OnMoveRight;
        input.OnMoveStopInputEvent += OnMoveStop;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }

    private void OnJump()
    {
        if (grounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerAttributes.speed * rigid.gravityScale / 2);
        }
    }

    private void OnMoveLeft()
    {
        rigid.velocity = new Vector2(-playerAttributes.speed, rigid.velocity.y);
        playerRenderer.flipX = true;
    }

    private void OnMoveRight()
    {
        rigid.velocity = new Vector2(playerAttributes.speed, rigid.velocity.y);
        playerRenderer.flipX = false;
    }

    private void OnMoveStop()
    {
        rigid.velocity = new Vector2(Mathf.Lerp(rigid.velocity.x, 0f, 0.1f), rigid.velocity.y);
    }
}
