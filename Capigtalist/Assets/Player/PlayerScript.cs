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
    PlayerFeetScript feet;

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
    }

    private void Start()
    {
        input.OnJumpInputEvent += OnJump;
        input.OnMoveLeftInputEvent += OnMoveLeft;
        input.OnMoveRightInputEvent += OnMoveRight;
        input.OnMoveStopInputEvent += OnMoveStop;

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
            playerAttributes.AddMoney(1);
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

    public void Die()
    {
        // TODO: die direito
        SceneManager.LoadScene(0);
    }
}
