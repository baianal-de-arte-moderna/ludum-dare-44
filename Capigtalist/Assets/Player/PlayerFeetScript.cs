using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetScript : MonoBehaviour
{
    public delegate void Bounce();
    public bool grounded;
    public Bounce onBounce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
        if ((!collision.CompareTag("Floor")) && onBounce != null)
        {
            onBounce();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
