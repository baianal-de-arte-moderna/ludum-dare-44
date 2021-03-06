﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public delegate void PlayerHealthChange();
    public PlayerHealthChange OnPlayerHealthChange;
    public PlayerHealthChange OnPlayerDeath;

    [HideInInspector]
    public float hp;
    [HideInInspector]
    public float maxHp;

    public float speed;
    public float jumpSpeed;
    public int invincibilityCooldownMillis;

    private void Awake()
    {
        hp = GameData.hp;
        maxHp = GameData.maxHp;
    }

    public void HealthChange(float value)
    {
        if((hp==0) && (value<0))
        {
            OnPlayerDeath?.Invoke();
        }
        hp = Mathf.Max(0, Mathf.Min(hp + value, maxHp));
        OnPlayerHealthChange?.Invoke();
    }
}
