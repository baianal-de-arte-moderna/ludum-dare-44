using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour
{
    Transform playerTransform;
    SpriteRenderer starRenderer;
    public float levelSize;
    float previousX;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        starRenderer = GetComponent<SpriteRenderer>();
        updatePreviousXPosition();
    }

    void FixedUpdate()
    {
        if(playerTransform.position.x > previousX)
        {
            starRenderer.color = new Color(1, 1, 1, previousX/levelSize);
            updatePreviousXPosition();
        }
    }

    void updatePreviousXPosition()
    {
        previousX = playerTransform.position.x;
    }
}
