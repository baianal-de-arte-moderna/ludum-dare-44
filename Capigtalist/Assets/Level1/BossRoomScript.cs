using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomScript : MonoBehaviour
{
    public Collider2D PlayerEnterTrigger;
    public Collider2D RoomBarrierCollider;
    public RoomBarrierSpriteScript RoomBarrierSprite;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            PlayerEnterTrigger.enabled = false;
            RoomBarrierCollider.enabled = true;
            RoomBarrierSprite.enabled = true;
        }
    }
}
