using UnityEngine;
using System.Collections;

public class PlayerWeakPoint : MonoBehaviour
{
    public delegate void PlayerWeakPointTouchEvent(float damage);
    public event PlayerWeakPointTouchEvent OnPlayerWeakPointTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerWeakPointTouch?.Invoke(GameData.damageList[collision.gameObject.name]);
    }
}
