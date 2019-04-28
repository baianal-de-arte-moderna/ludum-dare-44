using UnityEngine;
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

        jumpBehaviour = PlayerAttributes.jumpBehaviour;
    }

    private void Start()
    {
        input.OnJumpInputEvent += OnJump;
        input.OnMoveLeftInputEvent += OnMoveLeft;
        input.OnMoveRightInputEvent += OnMoveRight;
        input.OnMoveStopInputEvent += OnMoveStop;
        playerAttributes.OnPlayerDeath += Die;
        feet.onBounce += OnJump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillPlane"))
        {
            Die();
        }
        if (collision.CompareTag("CollectMoney"))
        {
            playerAttributes.HealthChange(1);
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

    public void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
