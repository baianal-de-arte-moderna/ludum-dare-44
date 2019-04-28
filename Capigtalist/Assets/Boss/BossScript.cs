using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(BossAttributes))]
public class BossScript : MonoBehaviour
{
    [SerializeField]
    private Throwable hammerPrefab;
    [SerializeField]
    private Throwable sicklePrefab;

    private SpriteRenderer bossRenderer;
    private BossAttributes bossAttributes;

    private bool isInvincible = false;
    private bool hasHammer = true;
    private bool hasSickle = true;

    private void Awake()
    {
        bossRenderer = GetComponent<SpriteRenderer>();
        bossAttributes = GetComponent<BossAttributes>();
    }

    private void Start()
    {
        HeadScript headScript = GetComponentInChildren<HeadScript>();
        headScript.OnPlayerHit += OnPlayerHit;

        HammerRadar hammerRadar = GetComponentInChildren<HammerRadar>();
        hammerRadar.OnPlayerStayHammerRadar += OnPlayerStayHammerRadar;

        SickleRadar sickleRadar = GetComponentInChildren<SickleRadar>();
        sickleRadar.OnPlayerStaySickleRadar += OnPlayerStaySickleRadar;
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

    public Vector2 GetCenter()
    {
        return bossRenderer.bounds.center;
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

    private void OnPlayerStayHammerRadar(PlayerScript playerScript)
    {
        if (hasHammer)
        {
            Throw(hammerPrefab, playerScript, bossAttributes.hammerSpeed, bossAttributes.hammerCooldownMillis, RecoverHammer);
            hasHammer = false;
        }
    }

    private void OnPlayerStaySickleRadar(PlayerScript playerScript)
    {
        if (hasSickle)
        {
            Throw(sicklePrefab, playerScript, bossAttributes.sickleSpeed, bossAttributes.hammerCooldownMillis, RecoverSickle);
            hasSickle = false;
        }
    }

    private void Throw(Throwable throwablePrefab, PlayerScript playerScript, float speed, int recoverCooldownMillis, Action recoverThrowableAction)
    {
        Vector2 startPosition = GetCenter();
        Vector2 finalPosition = playerScript.GetCenter();
        Vector2 throwDirection = (finalPosition - startPosition).normalized;

        Throwable throwable = Instantiate(throwablePrefab);
        throwable.transform.position = startPosition;
        throwable.rigidbody.velocity = throwDirection * speed;
        throwable.rigidbody.angularVelocity = 180;

        Destroy(throwable, recoverCooldownMillis);

        Task.Factory.StartNew(async () =>
        {
            await Task.Delay(recoverCooldownMillis);
            recoverThrowableAction();
        });
    }

    private void RecoverHammer()
    {
        hasHammer = true;
    }

    private void RecoverSickle()
    {
        hasSickle = true;
    }
}
