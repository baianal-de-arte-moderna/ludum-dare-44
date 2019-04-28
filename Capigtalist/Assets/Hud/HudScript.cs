using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    private const float MIN_Y_POS = -3.3f;
    private const float MAX_Y_POS = 4.3f;
    private const float Y_RANGE = MAX_Y_POS - MIN_Y_POS;
    private const float X_FIXED_POS = -11.2f;
    private PlayerAttributes playerAttributes;

    void Start()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        playerAttributes.OnPlayerHealthChange += HealthHudUpdate;
        float newYPosition = CalculateYPosition(PlayerAttributes.hp);
        transform.localPosition = new Vector3(X_FIXED_POS, CalculateYPosition(PlayerAttributes.hp), 0f);
    }

    void HealthHudUpdate()
    {
        Vector3 newPos = new Vector3(X_FIXED_POS, CalculateYPosition(PlayerAttributes.hp), 0f);
        Debug.Log("UPDATING HEALTH WITH "+newPos.ToString());
        transform.localPosition = newPos;
    }

    float CalculateYPosition(float hp)
    {
        float hpPercentage = PlayerAttributes.hp / PlayerAttributes.maxHp;
        return MIN_Y_POS + (hpPercentage * Y_RANGE);
    }
}
