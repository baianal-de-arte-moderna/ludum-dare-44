using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    public delegate void HeadTouchEvent();
    public event HeadTouchEvent OnHeadTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHeadTouch?.Invoke();
    }
}
