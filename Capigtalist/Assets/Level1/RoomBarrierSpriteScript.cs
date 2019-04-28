using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBarrierSpriteScript : MonoBehaviour
{
    // Update is called once per frame
    Vector3 finalPosition = new Vector3(-17.9f, 0f, 0f);
    void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            finalPosition,
            0.03f
        );
    }
}
