﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomScript : MonoBehaviour
{
    public delegate void BossTriggered();
    public Collider2D PlayerEnterTrigger;
    public Collider2D RoomBarrierCollider;
    public RoomBarrierSpriteScript RoomBarrierSprite;
    public BossTriggered onBossTriggered;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RoomBarrierCollider.enabled = true;
            PlayerEnterTrigger.enabled = false;
            RoomBarrierSprite.enabled = true;
            onBossTriggered?.Invoke();
        }
    }
}
