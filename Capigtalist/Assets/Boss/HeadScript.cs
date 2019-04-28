using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    public delegate void PlayerHitEvent();
    public event PlayerHitEvent OnPlayerHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerHit?.Invoke();
    }
}
