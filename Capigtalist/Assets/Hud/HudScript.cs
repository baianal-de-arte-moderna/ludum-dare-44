using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private PlayerAttributes playerAttributes;

    private float minY;
    private float maxY;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        minY = rectTransform.localPosition.y;
        maxY = 0;
    }

    private void Start()
    {
        playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
        playerAttributes.OnPlayerHealthChange += HealthHudUpdate;
        HealthHudUpdate();
    }

    private void HealthHudUpdate()
    {
        float hpFraction = playerAttributes.hp / playerAttributes.maxHp;

        Vector3 vector = rectTransform.localPosition;
        vector.Set(vector.x, minY + (maxY - minY) * hpFraction, vector.z);
        rectTransform.localPosition = vector;
    }
}
