using System.Collections;
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

    public void HealthChange(int value)
    {
        hp = Mathf.Min(hp + value, maxHp);
        OnPlayerHealthChange?.Invoke();

        if (hp < 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
