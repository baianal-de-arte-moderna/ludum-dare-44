using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float speed;
    public float hp;
    public float maxHp;
    public int invincibilityCooldownMillis;

    public delegate void PlayerHealthChange();
    public PlayerHealthChange OnPlayerHealthChange;

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
    }
}
