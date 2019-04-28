using System;
using System.Threading.Tasks;
using UnityEngine;

public class BossAttackScript : BossScript
{
    public delegate void OnHammerEvent();
    public event OnHammerEvent OnHammerThrow;
    public event OnHammerEvent OnHammerRecover;

    public delegate void OnSickleEvent();
    public event OnSickleEvent OnSickleThrow;
    public event OnSickleEvent OnSickleRecover;

    [SerializeField]
    private Throwable hammerPrefab;
    [SerializeField]
    private Throwable sicklePrefab;

    private bool hasHammer = true;
    private bool hasSickle = true;

    private void Start()
    {
        RadarFar radarFar = GetComponentInChildren<RadarFar>();
        radarFar.OnPlayerStayRadar += OnPlayerStayRadarFar;

        RadarNear radarNear = GetComponentInChildren<RadarNear>();
        radarNear.OnPlayerStayRadar += OnPlayerStayRadarNear;
    }

    private void OnPlayerStayRadarFar(PlayerScript playerScript)
    {
        if (hasHammer)
        {
            Throw(hammerPrefab, playerScript, bossAttributes.hammerSpeed, bossAttributes.hammerCooldownMillis, RecoverHammer);
            hasHammer = false;
            OnHammerThrow?.Invoke();
        }
    }

    private void OnPlayerStayRadarNear(PlayerScript playerScript)
    {
        if (hasSickle)
        {
            Throw(sicklePrefab, playerScript, bossAttributes.sickleSpeed, bossAttributes.hammerCooldownMillis, RecoverSickle);
            hasSickle = false;
            OnSickleThrow?.Invoke();
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
        OnHammerRecover?.Invoke();
    }

    private void RecoverSickle()
    {
        hasSickle = true;
        OnSickleRecover?.Invoke();
    }
}
