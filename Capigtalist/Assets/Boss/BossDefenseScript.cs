﻿using System.Threading.Tasks;
using UnityEngine;

public class BossDefenseScript : BossScript
{
    private bool isInvincible = false;
    HeadScript headScript;

    private void Start()
    {
        headScript = GetComponentInChildren<HeadScript>();
        headScript.OnHeadTouch += OnPlayerHit;
    }

    private void FixedUpdate()
    {
        if (isInvincible)
        {
            bossRenderer.color = new Color(1, 1, 1, Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup * 15f)));
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
                GameData.hp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().hp;
                // TODO: Load End-Level Scene
                MainMenuScript.RestartGame();
            }
        }
    }
}
