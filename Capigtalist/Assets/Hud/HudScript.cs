using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private PlayerAttributes playerAttributes;

    private float minY;
    private float maxY;
    public Text hpText;
    private CultureInfo unitedStatesEnglishCulture = new CultureInfo("en-US");

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
        float hp = playerAttributes.hp;
        hpText.text = (hp / 100).ToString("C", unitedStatesEnglishCulture);
        float hpFraction = hp / playerAttributes.maxHp;
        Vector3 vector = rectTransform.localPosition;
        vector.Set(vector.x, minY + (maxY - minY) * hpFraction, vector.z);
        rectTransform.localPosition = vector;
    }
}
