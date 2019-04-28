using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(PlayerAttributes))]
public class PlayerDefenseScript : MonoBehaviour
{
    private PlayerAttributes playerAttributes;
    private SpriteRenderer playerRenderer;

    private bool isInvincible = false;

    private void Awake()
    {
        playerAttributes = GetComponent<PlayerAttributes>();
        playerRenderer = GetComponent<SpriteRenderer>();
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

            playerAttributes.HealthChange(-1);
        }
    }
}
