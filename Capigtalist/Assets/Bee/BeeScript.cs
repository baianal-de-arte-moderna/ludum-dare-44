using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public Rigidbody2D body;
    int shouldChangeVelocity = 0;
    float velX;
    float velY;
    float attackVelocity = 8f;
    int velocityChangeFrequency = 5;
    float horizontalBound = 7;
    float verticalBound = 3;
    float upperBound;
    float lowerBound;
    float leftBound;
    float rightBound;
    float maxDistance = 8f;
    Vector3 playerPosition;
    Vector3 initialPos;
    Vector2 vector = new Vector2();

    public Collider2D playerCollider;
    public Collider2D floorCollider;
    public enum BeeState
    {
        ATTACKING,
        FLYING,
        IDLE,
        RECOVERING,
        START_RECOVER
    }

    BeeState state;
    bool shouldDamage;

    void Awake()
    {
        state = BeeState.FLYING;
    }

    void Start()
    {
        FloorRadarScript floorRadarScript = GetComponentInChildren<FloorRadarScript>();
        floorRadarScript.OnEnterRadar += OnEnterFloorRadar;

        PlayerRadarScript playerRadarScript = GetComponentInChildren<PlayerRadarScript>();
        playerRadarScript.OnEnterRadar += OnEnterPlayerRadar;

        body.freezeRotation = true;
        setBoundaries();
        initialPos = body.transform.position;
        shouldDamage = true;
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case BeeState.FLYING:

                if (shouldChangeVelocity == 0)
                {
                    velX = Random.Range(-2f,2f);
                    velY = Random.Range(-2f,2f);
                }
                shouldChangeVelocity = (shouldChangeVelocity + 1) % velocityChangeFrequency;

                if (velX > 0)
                {
                    if (transform.position.x + velX > rightBound)
                    {
                        velX *= -1;
                    }
                }
                else
                {
                    if (transform.position.x + velX < leftBound)
                    {
                        velX *= -1;
                    }
                }

                if (velY > 0) 
                {
                    if (transform.position.y + velY > upperBound)
                    {
                        velY *= -1;
                    }
                }
                else 
                {
                    if (transform.position.y + velY < lowerBound)
                    {
                        velY *= -1;
                    }
                }

                vector.Set(velX, velY);
                body.velocity = vector;
                break;

            case BeeState.ATTACKING:
            {
                Vector2 direction = playerPosition - transform.position;
                body.velocity = direction.normalized * attackVelocity;
                state = BeeState.IDLE;
                break;
            }

            case BeeState.START_RECOVER:
            {
                Vector2 direction = initialPos - transform.position;
                body.velocity = direction.normalized * 20f;
                state = BeeState.RECOVERING;
                break;
            }

            case BeeState.RECOVERING:
                if (transform.position.y > initialPos.y)
                {
                    state = BeeState.FLYING;
                    shouldDamage = true;
                    setBoundaries();
                    body.velocity = Vector2.zero;
                }
                break;

            case BeeState.IDLE:
                if (Vector2.Distance(initialPos, transform.position) > maxDistance)
                    state = BeeState.START_RECOVER;
                break;

            default:
                break;
        }
    }

    private void setBoundaries()
    {
        upperBound = transform.position.y + verticalBound;
        rightBound = transform.position.x + horizontalBound;
        leftBound = transform.position.x - horizontalBound;
        lowerBound = transform.position.y - verticalBound;
    }

    private void OnEnterPlayerRadar(Collider2D other)
    {
        if (state == BeeState.FLYING)
        {
            playerPosition = other.transform.position;
            state = BeeState.ATTACKING;
        }
    }

    private void OnEnterFloorRadar()
    {
        if (state == BeeState.ATTACKING || state == BeeState.IDLE)
        {
            state = BeeState.START_RECOVER;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (state == BeeState.ATTACKING || state == BeeState.IDLE)
        {
            state = BeeState.START_RECOVER;
        }
    }
}
