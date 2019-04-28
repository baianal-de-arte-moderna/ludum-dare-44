using UnityEngine;
using System.Collections;

public class BossMovementScript : BossScript
{
    private Rigidbody2D bossRigidbody;

    override protected void Awake()
    {
        base.Awake();
        bossRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        RadarFar radarFar = GetComponentInChildren<RadarFar>();
        radarFar.OnPlayerEnterRadar += OnPlayerEnterRadarFar;
        radarFar.OnPlayerLeaveRadar += OnPlayerLeaveRadarFar;

        RadarNear radarNear = GetComponentInChildren<RadarNear>();
        radarNear.OnPlayerEnterRadar += OnPlayerEnterRadarNear;
    }

    private void OnPlayerEnterRadarFar(PlayerScript playerScript)
    {
        if (playerScript.transform.position.x < transform.position.x)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    private void OnPlayerLeaveRadarFar(PlayerScript playerScript)
    {
        MoveStop();
    }

    private void OnPlayerEnterRadarNear(PlayerScript playerScript)
    {
        Jump();
        if (playerScript.transform.position.x < transform.position.x)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void Jump()
    {
        if (true)
        {
            bossRigidbody.velocity = new Vector2(bossRigidbody.velocity.x, bossAttributes.verticalSpeed * bossRigidbody.gravityScale / 2);
        }
    }

    private void MoveLeft()
    {
        bossRigidbody.velocity = new Vector2(-bossAttributes.horizontalSpeed, bossRigidbody.velocity.y);
        bossRenderer.flipX = true;
    }

    private void MoveRight()
    {
        bossRigidbody.velocity = new Vector2(bossAttributes.horizontalSpeed, bossRigidbody.velocity.y);
        bossRenderer.flipX = false;
    }

    private void MoveStop()
    {
        bossRigidbody.velocity = new Vector2(Mathf.Lerp(bossRigidbody.velocity.x, 0f, 0.1f), bossRigidbody.velocity.y);
    }
}
