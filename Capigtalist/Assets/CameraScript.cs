using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    Collider2D cameraCollider;
    CinemachineConfiner cameraConfine;

    void Start()
    {
        cameraConfine = GetComponent<CinemachineConfiner>();
    }

    void FixedUpdate()
    {
        if (cameraCollider == null)
        {
            cameraCollider = GameObject.FindGameObjectWithTag("CameraCollider").GetComponent<Collider2D>();
            cameraConfine.m_BoundingShape2D = cameraCollider;
        }

        
    }
}
