using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenScript : MonoBehaviour
{
    TextLoadingScript textLoading;
    public RectTransform panel;

    Vector2 panelPos;

    void Start()
    {
        textLoading = GetComponentInChildren<TextLoadingScript>();
        panelPos = Vector2.zero;
    }
    void FixedUpdate()
    {
        panel.offsetMax = Vector2.Lerp(
            panel.offsetMax,
            panelPos,
            0.1f
        );
        if (-1920f > panel.offsetMax.x)
        {
            Destroy(gameObject);
        }
    }
    public void EndLoading()
    {
        panelPos.x = -2000f;
    }
}
