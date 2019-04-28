using UnityEngine;
using System.Collections;

public class FeetScript : MonoBehaviour
{
    public delegate void FeetTouchEvent();
    public event FeetTouchEvent OnFeetTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnFeetTouch?.Invoke();
    }
}
