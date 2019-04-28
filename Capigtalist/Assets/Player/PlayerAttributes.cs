using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static int hp = 5;
    public static int maxHp = 10;
    public static JumpBehaviour jumpBehaviour = new RegularJumpBehaviour();

    public delegate void PlayerHealthChange();
    public PlayerHealthChange OnPlayerHealthChange;
    public PlayerHealthChange OnPlayerDeath;

    public float speed;

    public int invincibilityCooldownMillis;

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
