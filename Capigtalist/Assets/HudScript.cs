using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    private const float MIN_Y_POS = -3.1f;
    private const float MAX_Y_POS = 4.4f;
    private const float Y_RANGE = MAX_Y_POS - MIN_Y_POS;
    private const float X_FIXED_POS = -1.1f;
    private PlayerAttributes playerAttributes;

    void Start()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();

        playerAttributes.OnPlayerHealthChange += HealthHudUpdate;

        float newYPosition = CalculateYPosition(playerAttributes.hp);

        transform.position = new Vector3(X_FIXED_POS, CalculateYPosition(playerAttributes.hp), 0f);
    }

    void HealthHudUpdate()
    {
        transform.position = new Vector3(X_FIXED_POS, CalculateYPosition(playerAttributes.hp), 0f);
    }

    float CalculateYPosition(float hp)
    {
        float hpPercentage = playerAttributes.hp / playerAttributes.maxHp;
        return MIN_Y_POS + (hpPercentage * Y_RANGE);
    }
}
