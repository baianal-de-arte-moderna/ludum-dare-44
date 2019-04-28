using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float speed;
    public float hp;
    public float maxHp;
    private static float MIN_HP = -1f;
    public int invincibilityCooldownMillis;

    public delegate void PlayerHealthChange();
    public PlayerHealthChange OnPlayerHealthChange;
    public delegate void PlayerDeath();
    public PlayerDeath OnPlayerDeath;

    public void HealthChange(int value)
    {
        if (hp + value > maxHp)
        {
            hp = maxHp;
        }
        else
        {
            hp += value;
        }
        OnPlayerHealthChange?.Invoke();
        if (hp <= MIN_HP)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
