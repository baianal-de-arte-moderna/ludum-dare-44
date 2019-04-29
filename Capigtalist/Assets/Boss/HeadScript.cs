using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    Collider2D col;
    public delegate void HeadTouchEvent();
    public event HeadTouchEvent OnHeadTouch;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHeadTouch?.Invoke();
    }

    public void SetHeadActive(bool active)
    {
        col.enabled = active;
    }
}
