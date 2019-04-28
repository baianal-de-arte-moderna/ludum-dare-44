using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(PlayerAttributes))]
public class PlayerDefenseScript : MonoBehaviour
{
    private PlayerAttributes playerAttributes;
    private PlayerScript playerScript;
    private SpriteRenderer playerRenderer;

    private bool isInvincible = false;

    private void Awake()
    {
        playerAttributes = GetComponent<PlayerAttributes>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerScript>();
    }

    private void Start()
    {
        PlayerWeakPoint playerWeakPoint = GetComponentInChildren<PlayerWeakPoint>();
        playerWeakPoint.OnPlayerWeakPointTouch += OnWeakPointTouch;
    }

    private void FixedUpdate()
    {
        if (isInvincible)
        {
            playerRenderer.color = new Color(1, 1, 1, Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup * 15f)));
        }
        else
        {
            playerRenderer.color = Color.white;
        }
    }

    private void OnWeakPointTouch()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(playerAttributes.invincibilityCooldownMillis);
                isInvincible = false;
            });

            playerAttributes.hp--;
            if (playerAttributes.hp <= 0)
            {
                playerScript.Die();
            }
        }
    }
}
