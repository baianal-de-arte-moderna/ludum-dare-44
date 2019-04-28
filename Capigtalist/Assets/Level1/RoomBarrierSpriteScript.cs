using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBarrierSpriteScript : MonoBehaviour
{
    // Update is called once per frame
    Vector3 finalPosition = new Vector3(-1.69f, -1.5f, 0f);
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            finalPosition,
            0.1f
        );
    }
}
