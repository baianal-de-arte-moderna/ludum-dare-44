using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightScript : MonoBehaviour
{
    Transform playerTransform;
    float previousX;
    public float timeRate;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        updatePreviousXPosition();
    }

    void FixedUpdate()
    {
        if(playerTransform.position.x > previousX)
        {
            transform.position = new Vector3(transform.position.x ,transform.position.y-(timeRate/1000), transform.position.z);
            updatePreviousXPosition();
        }
    }

    void updatePreviousXPosition()
    {
        previousX = playerTransform.position.x;
    }
}
