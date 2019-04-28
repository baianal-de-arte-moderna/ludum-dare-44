using System.Threading.Tasks;
using UnityEngine;

public class BossDefenseScript : BossScript
{
    private bool isInvincible = false;

    private void Start()
    {
        HeadScript headScript = GetComponentInChildren<HeadScript>();
        headScript.OnPlayerHit += OnPlayerHit;
    }

    private void FixedUpdate()
    {
        if (isInvincible)
        {
            bossRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            bossRenderer.color = Color.white;
        }
    }

    private void OnPlayerHit()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(bossAttributes.invincibilityCooldownMillis);
                isInvincible = false;
            });

            bossAttributes.hitPoints--;
            if (bossAttributes.hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
