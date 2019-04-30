using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(PlayerAttributes))]
public class PlayerDefenseScript : MonoBehaviour
{
    private PlayerAttributes playerAttributes;
    private SpriteRenderer playerRenderer;
    ParticleSystem damageParticles;

    private bool isInvincible = false;

    private void Awake()
    {
        playerAttributes = GetComponent<PlayerAttributes>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        damageParticles = GetComponentInChildren<ParticleSystem>();

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

    private void OnWeakPointTouch(float damage)
    {
        if ((!isInvincible) && (damage > 0))
        {
            isInvincible = true;
            damageParticles.Play();
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(playerAttributes.invincibilityCooldownMillis);
                isInvincible = false;
            });
            playerAttributes.HealthChange(-damage);
        }
        else if (damage < 0)
        {
            playerAttributes.HealthChange(-damage);
        }
    }
}
