using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float speed;
    public float hp;
    public int invincibilityCooldownMillis;

    public void AddMoney(int value)
    {
        hp += value;
    }
}
